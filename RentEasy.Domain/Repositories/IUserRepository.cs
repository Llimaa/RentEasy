using RentEasy.Domain.Commands.Auth;
using RentEasy.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RentEasy.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void AlterPassword(User user);

        Task<User> GetUserByEmail(string email);
        Task<bool> UserExisteByEmail(string email);
        Task<User> GetUserById(Guid id);
    }
}
