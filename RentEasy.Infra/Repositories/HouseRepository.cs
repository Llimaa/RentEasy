using Microsoft.EntityFrameworkCore;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using RentEasy.Domain.Repositories;
using RentEasy.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentEasy.Infra.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly Context _context;

        public HouseRepository(Context context)
        {
            _context = context;
        }

        public void Create(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
        }

        public void Update(House house)
        {
            _context.Entry(house).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<House>> GetHousersByIdProfile(Guid profileId)
        {
            return await _context.Houses.AsNoTracking().Where(HouseQueries.GetHousersByIdProfile(profileId)).Include("Photo").ToListAsync();
        }

        public async Task<House> GetById(Guid id)
        {
            return await _context.Houses.AsNoTracking().Where(HouseQueries.GetById(id)).Include("Photo").Include("Profile").FirstOrDefaultAsync();
        }
    }
}
