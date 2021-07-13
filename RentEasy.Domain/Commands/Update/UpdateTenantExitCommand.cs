using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateTenantExitCommand : Notifiable, ICommand
    {

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
           .Requires()
           .IsNotNullOrEmpty(Id.ToString(), "Id", "O Id é necessário")
           );
        }
    }
}
