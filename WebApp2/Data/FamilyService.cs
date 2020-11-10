using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApp2.Data;
using WebApp2.DataAccess;

namespace WebApp2.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private FamilyDBContext ctx;

        public FamilyService(FamilyDBContext ctx)
        {
            this.ctx = ctx;
           // updateFamilyList();
        }
        

//     private void WriteFamiliesFile()
//     {
//         string productsAsJson = JsonSerializer.Serialize(families);
//         File.WriteAllText(familyFile, productsAsJson);
//         updateFamilyList();
//       }

//      public async void updateFamilyList()
//      {
//          if (ctx.Families.ToList().Count == 0)
//          {
//              string content = File.ReadAllText(familyFile);
//              families = JsonSerializer.Deserialize<IList<Family>>(content);
//              foreach (var family in families)
//              {
//                  ctx.Families.AddAsync(family);
//                  await ctx.SaveChangesAsync();
//              }
//          }
//
//      }
      
            
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            List<Family> families = await ctx.Families.ToListAsync();
            foreach (var family in families)
            {
                family.Children ??= ctx.Children.Where(c => c.FamilyId == family.Id).ToList();
                family.Adults ??= ctx.Adults.Where(a => a.FamilyId == family.Id).ToList();
                family.Pets ??= ctx.Pets.Where(p => p.FamilyId == family.Id).ToList();
            }

            return families;
        }
        
        public async Task<Family> AddFamilyAsync(Family family)
        {
            await ctx.Families.AddAsync(family);
            await ctx.SaveChangesAsync();
            return family;
        }
        
        public async Task RemoveFamilyAsync(string StreetName, int HouseNumber)
        {
            Family toRemove = ctx.Families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
            ctx.Remove(toRemove);
            await ctx.SaveChangesAsync();
        }

        public async Task<Family> GetFamilyAsync(string StreetName, int HouseNumber)
        {
            return await ctx.Families.FirstAsync(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
        }
        
    }
}