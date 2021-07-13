using RentEasy.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace RentEasy.Domain.Queries
{
    public static class TenantQueries
    {
        public static Expression<Func<Tenant, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Tenant, bool>> GetTenantByHouseId(Guid houseId)
        {
            return x => x.HouseId == houseId;
        }
    }
}
