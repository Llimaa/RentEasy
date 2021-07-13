using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdateProfileCommand : Notifiable, ICommand
    {
        public UpdateProfileCommand()
        {

        }
        public UpdateProfileCommand(
            string name,
            string phone,
            Guid id,
              string street,
              string number,
              string neighborhood,
              string city,
              string state,
              string zipCode

            )
        {
            Id = id;
            Name = name;
            Phone = phone;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
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
                .HasMaxLen(Phone, 15, "Profile.Phone", "Numero telefone inválido")
                .IsNotNullOrEmpty(Name, "Profile.Name", "O Nome é Obrigatório")

                  .IsNotNullOrEmpty(Street.ToString(), "Street", "campo Street é obrigatório")
                 .IsNotNullOrEmpty(Number.ToString(), "Number", "campo Number é obrigatório")
                 .IsNotNullOrEmpty(Neighborhood.ToString(), "Neighborhood", "campo Neighborhood é obrigatório")
                 .IsNotNullOrEmpty(State.ToString(), "State", "campo State é obrigatório")
                 .IsNotNullOrEmpty(ZipCode.ToString(), "ZipCode", "campo ZipCode é obrigatório")
                );
        }
    }
}
