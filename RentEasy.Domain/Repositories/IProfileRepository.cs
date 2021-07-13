using RentEasy.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RentEasy.Domain.Repositories
{
    public interface IProfileRepository
    {
        void Create(Profile profile);
        void Update(Profile profile);

        Task<Profile> GetById(Guid id);
    }
}
