using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateTenantLastPaymentDateCommand : Notifiable, ICommand
    {

        public UpdateTenantLastPaymentDateCommand()
        {

        }

        public UpdateTenantLastPaymentDateCommand(DateTime lastPaymentDate, Guid id)
        {
            Id = id;
            LastPaymentDate = lastPaymentDate;
        }

        public Guid Id { get; set; }
        public DateTime LastPaymentDate { get;   set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(LastPaymentDate.ToString(), "LastPaymentDate", "O LastPaymentDate é necessário")
               );
        }
    }
}
