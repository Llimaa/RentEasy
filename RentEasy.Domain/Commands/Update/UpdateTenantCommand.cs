using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateTenantCommand : Notifiable, ICommand
    {

        public UpdateTenantCommand()
        {

        }

        public UpdateTenantCommand(string name, string phone, int payDay, Guid id)
        {
            Id = id;
            Name = name;
            Phone = phone;
            PayDay = payDay;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int PayDay { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(Name, "Name", "O Nome é necessário")
                 .IsNotNullOrEmpty(Phone, "Phone", "O Phone é necessário")
                .IsNotNullOrEmpty(PayDay.ToString(), "DatePayment", "A DatePayment é necessária")
               );
        }
    }
}
