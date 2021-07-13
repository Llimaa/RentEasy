using RentEasy.Domain.Enuns;
using RentEasy.Shared.Entities;
using System;

namespace RentEasy.Domain.Entities
{
    public class Tenant : Entity
    {
        public Tenant()
        {

        }
        public Tenant(string name, string phone, int payDay, Guid houseId)
        {
            Name = name;
            Phone = phone;
            PayDay = payDay;
            HouseId = houseId;
            StatusPayment = StatusPayment.PaidOut;
            StatusTenant = StatusTenant.Active;
            DateStart = DateTime.Now;

        }

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public StatusPayment StatusPayment { get; private set; }
        public StatusTenant StatusTenant { get; private set; }
        public int PayDay { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateExit { get; private set; }
        public DateTime LastPaymentDate { get; private set; }
        public Guid HouseId { get; private set; }
        public House House { get; private set; }

        public void Update(string name, string phone, int payDay)
        {
            Name = name;
            Phone = phone;
            PayDay = payDay;
        }

        public void UpdateStatusPayment(StatusPayment status)
        {
            StatusPayment = status;
        }

        public void TenantExit()
        {
            StatusTenant = StatusTenant.Desactive;
        }

        public void TenantActive()
        {
            StatusTenant = StatusTenant.Active;
        }

        public void UpdateLastPaymentDate(DateTime date)
        {
            LastPaymentDate = date;
        }

        public int HowManyDaysOfLate( )
        {
            return (int)LastPaymentDate.Subtract(DateTime.Today).TotalDays;
        }
    }
}
