using ParkyAPI.Repository.IRepository;
using ParkyAPI.Models;
using ParkyAPI.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;

        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<NationalPark>> GetNationalParks() =>
            await _db.NationalParks.OrderBy(x => x.Name).ToListAsync();
        
        public async Task<NationalPark> GetNationalPark(int nationalParkId) =>
            await _db.NationalParks.FirstOrDefaultAsync(x => x.Id == nationalParkId);

        public async Task<bool> NationalParkExists(string name) => 
            await _db.NationalParks.AnyAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
        
        public async Task<bool> NationalParkExists(int id) =>
            await _db.NationalParks.AnyAsync(x => x.Id == id);

        public async Task<bool> CreateNationalPark(NationalPark nationalPark)
        {

            await _db.NationalParks.AddAsync(nationalPark);
            return await Save();
        }
        public async Task<bool> UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return await Save();
        }
        public async Task<bool> DeleteNationalPark(NationalPark nationalPark)
        {

            _db.NationalParks.Remove(nationalPark);
            return await Save();
        }

        public async Task<bool> Save() =>
            await _db.SaveChangesAsync() >= 0 ? true : false;
    }
}