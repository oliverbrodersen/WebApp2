using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApp2.Models;

namespace Models {
public class Child : Person {
    
    [JsonIgnore]
    public List<ChildInterest> ChildInterests { get; set; } 
    [JsonIgnore]
    public List<ChildInterestTable> ChildInterestTables { get; set; }
   // public List<Pet> Pets { get; set; }

    public void Update(Child toUpdate) {
        base.Update(toUpdate);
        ChildInterestTables = toUpdate.ChildInterestTables;
       // Pets = toUpdate.Pets;
    }
    }
}