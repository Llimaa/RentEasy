using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Domain.Enuns;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateStatusPaymentTenantCommand : Notifiable, ICommand
    {

        public UpdateStatusPaymentTenantCommand()
        {

        }

        public UpdateStatusPaymentTenantCommand(StatusPayment statusPayment,Guid id)
        {
            Id = id;
            StatusPayment = statusPayment;
        }

        public Guid Id { get; set; }
        public StatusPayment StatusPayment { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(StatusPayment.ToString(), "Name", "O Nome é necessário")
               );
        }
    }
}
