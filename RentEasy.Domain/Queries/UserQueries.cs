using RentEasy.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace RentEasy.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email.Address == email;
        }
    }
}
