using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models {
public class Family {

        [Key]    
        public int Id { get; set; }

        [NotNull]
        [Required(AllowEmptyStrings = false)]
        public string StreetName { get; set; }

    [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid house number")]
        public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }

        public bool containsAdult(string str)
        {
            foreach (var f in Adults)
            {
                if ((f.FirstName.ToLower()).Contains(str) || (f.LastName.ToLower()).Contains(str))
                    return true;
            }
            return false;
        }
        public bool containsPet(string str)
        {
            foreach (var f in Pets)
            {
                if ((f.Name.ToLower()).Contains(str))
                    return true;
            }
            return false;
        }
        public bool containsChild(string str)
        {
            foreach (var f in Children)
            {
                if ((f.FirstName.ToLower()).Contains(str) || (f.LastName.ToLower()).Contains(str))
                    return true;
            }
            return false;
        }
        public bool containsJob(string str)
        {
            foreach (var f in Adults)
            {
                if ((f.JobTitle.ToLower()).Contains(str))
                    return true;
            }
            return false;
        }
        public bool containsIntrest(string str)
        {
            foreach (var f in Children)
            {
                foreach(var i in f.ChildInterestTables)
                {
                    if ((i.InterestId.ToLower()).Contains(str))
                        return true;
                }
            }
            return false;
        }

    }


}