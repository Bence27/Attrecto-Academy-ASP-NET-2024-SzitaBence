using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public string CourseName { get; set; }
    }
}
