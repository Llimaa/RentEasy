using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;
namespace RentEasy.Domain.Commands.Auth
{
    public class UpdatePasswordCommand : Notifiable, ICommand
    {
        public UpdatePasswordCommand()
        {

        }
        public UpdatePasswordCommand(string email, string pastPassword, string newPassword, string confirmNewPassword)
        {
            Email = email;
            PastPassword = pastPassword;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmNewPassword;
        }

        public string Email { get; set; }
        public string PastPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Endereço de E-mail inválido")
                .IsTrue(NewPassword == ConfirmNewPassword ? true : false, "Nova senha", "os campos nova senha e confirma nova senha devem ser iguais")
                );
        }
    }
}
