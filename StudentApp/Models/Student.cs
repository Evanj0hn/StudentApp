using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0.0, 4.0)]
        public double GPA { get; set; }

        public string MyField { get; set; }

        [NotMapped]
        public int Age => DateTime.Today.Year - DateOfBirth.Year;

        [NotMapped]
        public string GPAScale =>
            GPA switch
            {
                >= 3.7 => "Excellent",
                >= 3.3 => "Very Good",
                >= 2.7 => "Good",
                >= 2.0 => "Satisfactory",
                _ => "Unsatisfactory"
            };

        [Required]
        [ForeignKey("Program")]
        public string ProgramCode { get; set; }  // FK

        public ProgramOfStudy Program { get; set; }  // Navigation
    }
}
