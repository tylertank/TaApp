using Microsoft.Build.Framework;
using TAApplication.Areas.Data;

namespace TAApplication.Models
{
        public enum Pursuing
        {
            BS, MS, PhD
        }
    public class Application
    {
        [Required]
        public Pursuing pursuing { get; set; }
        [Required]
        public string? Dept { get; set; }
        [Required]
        public int hours { get; set; }
        [Required]
        public bool avaliableBeforeSchoo { get; set; }
        [Required]
        public int semestersCompleted { get; set; }
        [Required]
        public string? transferSchool { get; set; }
        [Required]
        public string? linkedInURL { get; set; }
        [Required]
        public string? resumeFileName { get; set; }
        [Required]
        public DateTime Creation { get; set; }
        [Required]
        public DateTime lastModified { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public double GPA { get; set; }
        [Required]
        public int UserID { get; set; }

        public TAUser TAUser { get; set; } = null!;

    
    }
}
