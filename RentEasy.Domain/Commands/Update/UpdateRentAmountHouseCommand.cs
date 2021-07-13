using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateRentAmountHouseCommand : Notifiable, ICommand
    {
        public UpdateRentAmountHouseCommand()
        {

        }

        public UpdateRentAmountHouseCommand(decimal rentAmount, Guid id)
        {
            RentAmount = rentAmount;
            Id = id;
        }
        public Guid Id { get; set; }
        public decimal RentAmount { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(RentAmount, 100, "RentAmount", "O Preço do aluguel tem que ser maior que 100")
                );
        }
    }
}
