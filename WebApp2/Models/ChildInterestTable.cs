using Models;

namespace WebApp2.Models
{
    public class ChildInterestTable
    {
        public int Id { get; set; }
        public Child Child { get; set; }
        public string InterestId { get; set; }
        public ChildInterest ChildInterest { get; set; }
    }
}