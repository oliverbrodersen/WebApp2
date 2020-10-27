using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNPAssignment1.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family> AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(string StreetName, int HouseNumber);
        Task AddPetAsync(string StreetName, int HouseNumber, Pet pet);

        void updateFamilyList();
        Task<Family> GetFamilyAsync(string StreetName, int HouseNumber);

        Task AddAdultAsync(Adult adult, Family family);
    }
}