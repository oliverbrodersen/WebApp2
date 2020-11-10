using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Models {
public class Person {
    
    [Key]
    public int Id { get; set; }
    public int FamilyId { get; set; }
    [NotNull]
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [ValidHairColor]
    public string HairColor { get; set; }
    [NotNull]
    [ValidEyeColor]
    public string EyeColor { get; set; }
    [NotNull, Range(1, 125)]
    public int Age { get; set; }
    [NotNull, Range(1, 250)]
    public float Weight { get; set; }
    [NotNull, Range(1, Int32.MaxValue)]
    public int Height { get; set; }
    public string Sex { get; set; }

    public void Update(Person toUpdate) {
        Age = toUpdate.Age;
        Height = toUpdate.Height;
        HairColor = toUpdate.HairColor;
        Sex = toUpdate.Sex;
        Weight = toUpdate.Weight;
        EyeColor = toUpdate.EyeColor;
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
    }

}

public class ValidHairColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
            if(value == null)
                return new ValidationResult("Hair color not selected");
            else if (valid == null || valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
    }
    }
    public class ValidSex : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"Male", "Female", "Other"}.ToList();
            if (value == null)
                return new ValidationResult("Sex not selected");
            else if (valid == null || valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid genders are: Male, Female and Other");
        }
    }

    public class ValidEyeColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
            if (value == null)
                return new ValidationResult("Eye color not selected");
            else if (valid != null && valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
    }
}

}