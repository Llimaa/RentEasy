using RentEasy.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace RentEasy.Domain.Queries
{
    public static class ProfileQueries
    {
        public static Expression<Func<Profile, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
