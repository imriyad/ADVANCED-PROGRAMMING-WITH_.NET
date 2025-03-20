using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask2.Models
{

    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z .-]+$", ErrorMessage = "Name can only contain alphabets, dots, dashes, and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(@"^[A-Za-z]{2}\d-\d{5}-\d{1,3}$", ErrorMessage = "Id must be in the format XX-XXXXX-X")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [MinAge(18, ErrorMessage = "You must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}

