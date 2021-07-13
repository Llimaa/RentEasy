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
    public class ProfileRepository : IProfileRepository
    {
        private readonly Context _context;

        public ProfileRepository(Context context)
        {
            _context = context;
        }

        public void Create(Profile profile)
        {
            _context.Profile.Add(profile);
            _context.SaveChanges();
        }

        public async Task<Profile> GetById(Guid id)
       {
            return await _context.Profile.AsNoTracking().FirstOrDefaultAsync(ProfileQueries.GetById(id));
        }

        public void Update(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
