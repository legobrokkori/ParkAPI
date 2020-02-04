using ParkyAPI.Repository.IRepository;
using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        public Task<ICollection<NationalPark>> GetNationalParks()
        {
            throw new NotImplementedException();
        }
        public Task<NationalPark> GetNationalPark(int nationalParkId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> NationalParkExists(string name)
        {
            throw new NotImplementedException();
        }
        public Task<bool> NationalParkExists(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CreateNationalPark(NationalPark nationalPark)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateNationalPark(NationalPark nationalPark)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteNationalPark(NationalPark nationalPark)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}