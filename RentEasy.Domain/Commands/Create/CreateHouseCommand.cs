using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Create
{
    public class CreateHouseCommand : Notifiable, ICommand
    {
        public CreateHouseCommand()
        {

        }
        public CreateHouseCommand(
            string descricao,
            decimal rentAmount,
            Guid profileId,
              string street,
              string number,
              string neighborhood,
              string city,
              string state,
              string zipCode

            )
        {
            Descricao = descricao;
            RentAmount = rentAmount;
            ProfileId = profileId;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Descricao { get; set; }
        public decimal RentAmount { get; set; }

        public Guid ProfileId { get; set; }
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
                .IsGreaterThan(RentAmount, 100, "RentAmount", "O Preço do aluguel tem que ser maior que 100")
                .IsNotNullOrEmpty(ProfileId.ToString(), "ProfileId", "campo ProfileId obrigatório")

                 .IsNotNullOrEmpty(Street.ToString(), "Address.Street", "campo Street é obrigatório")
                 .IsNotNullOrEmpty(Number.ToString(), "Address.Number", "campo Number é obrigatório")
                 .IsNotNullOrEmpty(Neighborhood.ToString(), "Address.Neighborhood", "campo Neighborhood é obrigatório")
                 .IsNotNullOrEmpty(State.ToString(), "Address.State", "campo State é obrigatório")
                 .IsNotNullOrEmpty(ZipCode.ToString(), "Address.ZipCode", "campo ZipCode é obrigatório")
                );
        }
    }
}
