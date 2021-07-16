using Microsoft.EntityFrameworkCore;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using RentEasy.Domain.Repositories;
using RentEasy.Infra.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentEasy.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public void AlterPassword(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().Where(UserQueries.GetByEmail(email)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.AsNoTracking().Where(UserQueries.GetById(id)).FirstOrDefaultAsync();
        }

        public async Task<bool> UserExisteByEmail(string email)
        {
            var existe = await _context.Users.AsNoTracking().Where(UserQueries.GetByEmail(email)).Include("Profile").FirstOrDefaultAsync();
            return existe != null ? true : false;
        }
    }
}
