using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApp2.Models;

namespace Models
{
    public class ChildInterest
    {
        public int ChildId { get; set; }
        [JsonIgnore]
        public Child Child { get; set; }
        [Key]
        public string InterestId { get; set; }

        [JsonIgnore]
        public Interest Interest { get; set; }

        public IList<ChildInterestTable> ChildInterestTables { get; set; }
        public override bool Equals(object? obj)
        {
            ChildInterest ci = ((ChildInterest)obj);
            if (ci.Child.Equals(Child) && ci.Interest.Equals(Interest)) return true;
            return base.Equals(obj);
        }
        public ChildInterest copy()
        {
            return new ChildInterest() { InterestId = this.InterestId, Interest = this.Interest };
        }
    }
}
