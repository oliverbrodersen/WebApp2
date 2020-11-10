using System.Collections.Generic;
using WebApp2.Models;

namespace Models {
public class Child : Person {
    
    public List<ChildInterestTable> ChildInterestTables { get; set; }
   // public List<Pet> Pets { get; set; }

    public void Update(Child toUpdate) {
        base.Update(toUpdate);
        ChildInterestTables = toUpdate.ChildInterestTables;
       // Pets = toUpdate.Pets;
    }
    }
}