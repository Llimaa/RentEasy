using RentEasy.Domain.Enuns;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Entities;

namespace RentEasy.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(Email email, Password password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
            Status = StatusUser.Active;
        }

        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public string Role { get; private set; }
        public StatusUser Status { get; private set; }

        public Profile Profile { get; private set; }

        public void CreanPassword()
        {
            Password = new Password("");
        }

        public bool ValidateUser(string email, string password)
        {
            return email == Email.Address && new Password(password).Value == Password.Value && Status == StatusUser.Active ? true : false;
        }
    }
}
