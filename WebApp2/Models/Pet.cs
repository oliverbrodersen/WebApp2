using System.ComponentModel.DataAnnotations;

namespace Models {
public class Pet {
    [Key]
    public int RealId { get; set; }
    public int FamilyId { get; set; }
    public int Id { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
}
}