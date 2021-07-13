using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;

namespace RentEasy.Domain.Commands.Create
{
    public class CreateProfileCommand : Notifiable, ICommand
    {
        public CreateProfileCommand()
        {

        }
        public CreateProfileCommand(
          string name,
          string phone,
          string street,
          string number,
          string neighborhood,
          string city,
          string state,
          string zipCode
            )
        {
            Name = name;
            Phone = phone;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

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
                 .IsNotNullOrEmpty(Street, "Address.Street", "campo Street é obrigatório")
                 .IsNotNullOrEmpty(Number, "Address.Number", "campo Number é obrigatório")
                 .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "campo Neighborhood é obrigatório")
                 .IsNotNullOrEmpty(State, "Address.State", "campo State é obrigatório")
                 .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "campo ZipCode é obrigatório")
                );
        }
    }
}
