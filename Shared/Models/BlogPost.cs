using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Blank spaces are not allowed. You can separate words with '-' for ex.: my-first-post")]
        public string Url { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title is too long (50 character limit).")]
        public string Title { get; set; }
        [Required]
        public string Restaurant { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Diet { get; set; }
        [Range(-90.00, 90.00, ErrorMessage = "Coordinates must be a number between -90 and 90")]
        public double Latitude { get; set; }
        [Range(-180.00, 180.00, ErrorMessage = "Coordinates must be a number between -180 and 180")]
        public double Longitude { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ReviewerId { get; set; }
        public string Image { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be a number between 1 and 5")]
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public virtual Reviewer Reviewers { get; set; }
    }
}
