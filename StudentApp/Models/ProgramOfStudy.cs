using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class ProgramOfStudy
    {
        [Key]
        [Required]
        public string ProgramCode { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
