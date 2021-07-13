using RentEasy.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace RentEasy.Domain.Queries
{
    public static class HouseQueries
    {
        public static Expression<Func<House, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<House, bool>> GetHousersByIdProfile(Guid profileId)
        {
            return x => x.ProfileId == profileId;
        }
    }
}
