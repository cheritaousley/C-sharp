using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace restaurant.Models
{
    public class Review
    {
        public int id { get; set; }
        public string Reviewer_Name { get; set; }
        public string Restaurant_Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Stars { get; set; }
    }
    public class AddReviewViewModel : BaseEntity
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        // [Required, (ErrorMessage = "Name cannot be blank")]
        [MinLength(3)]
        public string Reviewer_Name { get; set; }

        [Required]
        // [Required, (ErrorMessage = "Name cannot be blank")]
        [MinLength(3)]
        public string Restaurant_Name { get; set; }

        [Required]
        // [Required, (ErrorMessage = "Review must be at least 10 characters long")]
        [MinLength(10)]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        // [Required, (ErrorMessage = "Date cannot be blank")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        // [Required, (ErrorMessage = "Rating cannot be blank")]
        [Range(0,5)]
        public int Stars{ get; set; }
    }
}
