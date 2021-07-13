using RentEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Domain.Queries
{
    public static class PhotoQueries
    {
        public static Expression<Func<Photo, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Photo, bool>> GetAllPhotoByHouseId(Guid houseId)
        {
            return x => x.HouseId == houseId;
        }
    }
}
