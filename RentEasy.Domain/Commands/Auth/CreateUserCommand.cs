using Flunt.Notifications;
using Flunt.Validations;
using RentEasy.Shared.Commands;

namespace RentEasy.Domain.Commands.Auth
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Endenreço de e-mail inválido")
                .HasMinLen(Password, 6, "Password", "A senha deve conter no minimo 6 caractéres")
                .IsNotNullOrEmpty(Role, "Role", "O User deve ter pelo menos uma Role")
                );
        }
    }
}
