using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateHouseCommand : Notifiable, ICommand
    {
        public UpdateHouseCommand()
        {

        }

        public UpdateHouseCommand(
            string descricao,
            Guid id,
              string street,
              string number,
              string neighborhood,
              string city,
              string state,
              string zipCode,
              decimal rentAmount
            )
        {
            Id = id;
            Descricao = descricao;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            RentAmount = rentAmount;

        }

        public Guid Id { get; set; }
        public decimal RentAmount { get; set; }
        public string Descricao { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Descricao, 10, "Description", "A Descrição esta muito pequena.")

                  .IsNotNullOrEmpty(Street.ToString(), "Address.Street", "campo Street é obrigatório")
                 .IsNotNullOrEmpty(Number.ToString(), "Address.Number", "campo Number é obrigatório")
                 .IsNotNullOrEmpty(Neighborhood.ToString(), "Address.Neighborhood", "campo Neighborhood é obrigatório")
                 .IsNotNullOrEmpty(State.ToString(), "Address.State", "campo State é obrigatório")
                 .IsNotNullOrEmpty(ZipCode.ToString(), "Address.ZipCode", "campo ZipCode é obrigatório")
                );
        }
    }
}
