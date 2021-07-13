using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Domain.Enuns;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateStatusHouseCommand : Notifiable, ICommand
    {
        public UpdateStatusHouseCommand()
        {

        }

        public UpdateStatusHouseCommand(StatusHouse status, Guid id)
        {
            Status = status;
            Id = Id;
        }
        public Guid Id { get; set; }
        public StatusHouse Status { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Status.ToString(), "Status", "Status é obrigátorio")
                );
        }
    }
}
