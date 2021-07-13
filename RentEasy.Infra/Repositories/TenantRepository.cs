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
    public class TenantRepository : ITenantRepository
    {
        private readonly Context _context;

        public TenantRepository(Context context)
        {
            _context = context;
        }

        public void Active(Tenant tenant)
        {
            _context.Entry(tenant.StatusTenant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Create(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            _context.SaveChanges();
        }

        public void Desactive(Tenant tenant)
        {
            _context.Entry(tenant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<Tenant> GetById(Guid id)
        {
            return await _context.Tenants.AsNoTracking().FirstOrDefaultAsync(TenantQueries.GetById(id));
        }

        public async Task<Tenant> GetTenantByHouseId(Guid houseId)
        {
            return await _context.Tenants.AsNoTracking().FirstOrDefaultAsync(TenantQueries.GetTenantByHouseId(houseId));
        }

        public void Update(Tenant tenant)
        {
            _context.Entry(tenant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<bool> ExisteTenantByHouseId(Guid houseId)
        {
            var res = await _context.Tenants.AsNoTracking().Where(TenantQueries.GetTenantByHouseId(houseId)).ToListAsync();
            return res.Count() > 0 ? true : false;
        }
    }
}
