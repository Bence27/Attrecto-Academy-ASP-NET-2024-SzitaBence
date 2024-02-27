using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class User
    {
        [Required]
        public int? Id { get; set; }

        [StringLength(10)]
        public string? FirstName { get; set; }

        [StringLength(10)]
        public string? LastName { get; set;}


    }
}
