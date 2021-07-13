using RentEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentEasy.Domain.Repositories
{
    public interface IPhotoRepository
    {
        void Create(Photo photo);
        void Update (Photo photo);
        void Delete(Guid id);
        Task<Photo> GetById(Guid id);
        Task<IEnumerable<Photo>> GetAllPhotoByHouseId(Guid houseId);
    }
}
