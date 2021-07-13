using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
using System;

namespace RentEasy.Domain.Commands.Update
{
    public class UpdatePhotoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public string Format { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Data, "Photo.Data", "base64 necessária")
                .IsNotNullOrEmpty(Format, "Photo.Format", "Format necessária")
                );
        }
    }
}
