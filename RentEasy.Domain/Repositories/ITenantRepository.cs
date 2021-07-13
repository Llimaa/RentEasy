using RentEasy.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RentEasy.Domain.Repositories
{
    public interface ITenantRepository
    {
        void Create(Tenant tenant);
        void Desactive(Tenant tenant);
        void Active(Tenant idtenant);
        void Update(Tenant tenant);

        Task<Tenant> GetById(Guid id);
        Task<Tenant> GetTenantByHouseId(Guid houseId);
        Task<bool> ExisteTenantByHouseId(Guid houseId);
    }
}
