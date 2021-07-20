using RentEasy.Domain.Entities;
using RentEasy.Domain.Enuns;
using RentEasy.Shared.Commands;
using System;


namespace RentEasy.Domain.Commands.Result
{
    public class UserResultCommand
    {
        public UserResultCommand()
        {

        }
        public UserResultCommand(string email, string role, StatusUser status)
        {
            Email = email;
            Role = role;
            Status = status;
        }

        public string Email { get; private set; }
        public string Role { get; private set; }
        public StatusUser Status { get; private set; }
    }
}
