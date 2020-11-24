using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using WebApp2.Data;
using WebApp2.DataAccess;
using WebApp2.Models;

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
        
        
//      public async void updateFamilyList()
//      {
//          if (ctx.Families.ToList().Count == 0)
//          {
//              string content = File.ReadAllText(familyFile);
//              IList<Family> families = JsonSerializer.Deserialize<IList<Family>>(content);
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
                family.Children = await ctx.Children.Where(c => c.FamilyId == family.Id).ToListAsync();
                family.Adults = await ctx.Adults.Where(a => a.FamilyId == family.Id).ToListAsync();
                family.Pets = await ctx.Pets.Where(p => p.FamilyId == family.Id).ToListAsync();
            }

            return families;
        }
        
        public async Task<Family> AddFamilyAsync(Family family)
        {
//            foreach (var c in family.Children)
//            {
//                EntityEntry<Child> newlyAdded = await ctx.Children.AddAsync(c);
//                await ctx.SaveChangesAsync();
//                c.Id = newlyAdded.Entity.Id;
//            }
//     
//            foreach (var c in family.Children)
//            {
//                foreach (var i in c.ChildInterests)
//                {
//                    Console.WriteLine(i.InterestId + c.Id);
//                    ChildInterestTable interestTable = new ChildInterestTable(){ChildInterest = i,Child = c,Id = c.Id, InterestId =  i.InterestId};
//                    c.ChildInterestTables.Add(interestTable);
//                }

//                c.ChildInterests = null;
//            }
            await ctx.Families.AddAsync(family);
            await ctx.SaveChangesAsync();
            return family;
        }
        
        public async Task RemoveFamilyAsync(string StreetName, int HouseNumber)
        {
            Family toRemove = ctx.Families.First(f => (f.StreetName.Equals(StreetName) && f.HouseNumber == HouseNumber));
            ctx.Remove(toRemove);
            await ctx.SaveChangesAsync();
        }

        public async Task<Family> GetFamilyAsync(string StreetName, int HouseNumber)
        {
            Family family = await ctx.Families.FirstAsync(f => (f.StreetName.Equals(StreetName) && f.HouseNumber == HouseNumber));
            family.Children = await ctx.Children.Where(c => c.FamilyId == family.Id).ToListAsync();
            family.Adults = await ctx.Adults.Where(a => a.FamilyId == family.Id).ToListAsync();
            family.Pets = await ctx.Pets.Where(p => p.FamilyId == family.Id).ToListAsync();
            return family;
        }
        
    }
}