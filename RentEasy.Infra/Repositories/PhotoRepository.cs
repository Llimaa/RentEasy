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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly Context _context;

        public PhotoRepository(Context context)
        {
            _context = context;
        }

        public void Create(Photo photo)
        {
            _context.Photo.Add(photo);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _context.Photo.Find(id);
            _context.Remove(item);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Photo>> GetAllPhotoByHouseId(Guid houseId)
        {
            return await _context.Photo.Where(PhotoQueries.GetAllPhotoByHouseId(houseId)).ToListAsync();
        }

        public async Task<Photo> GetById(Guid id)
        {
            return await _context.Photo.AsNoTracking().FirstOrDefaultAsync(PhotoQueries.GetById(id));
        }

        public void Update(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
