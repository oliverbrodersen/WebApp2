using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApp2.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family> AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(string StreetName, int HouseNumber);
        Task<Family> GetFamilyAsync(string StreetName, int HouseNumber);
        
    }
}