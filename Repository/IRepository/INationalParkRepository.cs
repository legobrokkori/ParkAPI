using System.Collections.Generic;
using System.Threading.Tasks;
using ParkyAPI.Models;

namespace ParkyAPI.Repository.IRepository
{
    public interface INationalParkRepository
    {
        Task<ICollection<NationalPark>> GetNationalParks();
        Task<NationalPark> GetNationalPark(int nationalParkId);
        Task<bool> NationalParkExists(string name);
        Task<bool> NationalParkExists(int id);
        Task<bool> CreateNationalPark(NationalPark nationalPark);
        Task<bool> UpdateNationalPark(NationalPark nationalPark);
        Task<bool> DeleteNationalPark(NationalPark nationalPark);
        Task<bool> Save();
    }
}