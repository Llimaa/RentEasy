using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Create
{
    public class CreatePhotoCommand : Notifiable, ICommand
    {
        public CreatePhotoCommand()
        {

        }

        public CreatePhotoCommand(string data, string format, Guid houseId)
        {
            Data = data;
            Format = format;
            HouseId = houseId;
        }

        public string Data { get; set; }
        public string Format { get; set; }
        public Guid HouseId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Data, "Photo.Data", "base64 necessária")
                .IsNotNullOrEmpty(Format, "Photo.Format", "Format necessária")
                 .IsNotNullOrEmpty(HouseId.ToString(), "Photo.HouseId", "HouseId necessária")
                );
        }
    }
}
