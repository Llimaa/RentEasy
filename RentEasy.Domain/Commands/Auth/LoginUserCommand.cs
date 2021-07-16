using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;

namespace RentEasy.Domain.Commands.Auth
{
    public class LoginUserCommand : Notifiable, ICommand
    {
        public LoginUserCommand()
        {

        }
        public LoginUserCommand(string email, string password, string role)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Endenreço de e-mail inválido")
                .HasMinLen(Password, 6, "Password", "A senha deve conter no minimo 6 caractéres")
                );
        }
    }
}
