using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace DNPAssignment1.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private IList<Family> families;

        public FamilyService()
        {
            if (!File.Exists(familyFile))
            {
                throw new System.NotImplementedException();
            }
            else
            {
                updateFamilyList();
                System.Console.WriteLine(families);
            }
        }

        private void WriteFamiliesFile()
        {
            string productsAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile, productsAsJson);
            updateFamilyList();
        }

        public void updateFamilyList()
        {
            string content = File.ReadAllText(familyFile);
            families = JsonSerializer.Deserialize<IList<Family>>(content);
        }
        
            
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            List<Family> tmp = new List<Family>(families);
            return tmp;
        }
        
        public async Task<Family> AddFamilyAsync(Family family)
        {
            families.Add(family);
            WriteFamiliesFile();
            return family;
        }
        
        public async Task RemoveFamilyAsync(string StreetName, int HouseNumber)
        {
            Family toRemove = families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
            families.Remove(toRemove);
            WriteFamiliesFile();
        }
        
        public async Task AddPetAsync(string StreetName, int HouseNumber, Pet pet)
        {
            Family toUpdate = families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
            toUpdate.Pets.Add(pet);
            WriteFamiliesFile();
        }
        
        
        public async Task<Family> GetFamilyAsync(string StreetName, int HouseNumber)
        {
            return families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
        }
        
        public async Task AddAdultAsync(Adult adult, Family family)
        {
            family.Adults.Add(adult);
        }
    }
}