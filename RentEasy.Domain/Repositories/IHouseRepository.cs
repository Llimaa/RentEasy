using RentEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentEasy.Domain.Repositories
{
    public interface IHouseRepository
    {
        void Create(House house);
        void Update(House house);
        Task<House> GetById(Guid id);
        Task<IEnumerable<House>> GetHousersByIdProfile(Guid profileId);
    }
}
