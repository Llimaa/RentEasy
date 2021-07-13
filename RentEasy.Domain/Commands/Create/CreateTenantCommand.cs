using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Create
{
    public class CreateTenantCommand : Notifiable, ICommand
    {
        public CreateTenantCommand()
        {
        }

        public CreateTenantCommand(string name, string phone, int payDay, Guid houseId)
        {
            Name = name;
            Phone = phone;
            PayDay = payDay;
            HouseId = houseId;
        }

        public string Name { get;   set; }
        public string Phone { get;   set; }
        public int PayDay { get;   set; }
        public Guid HouseId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Name, "Tenant.Name", "Name necessário")
                  .IsNotNullOrEmpty(Phone, "Tenant.Phone", "Telefone necessário")
                    .IsNotNullOrEmpty(HouseId.ToString(), "Tenant.Phone", "Telefone necessário")
                  ); ;
        }
    }
}
