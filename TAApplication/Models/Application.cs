using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using TAApplication.Areas.Data;

namespace TAApplication.Models
{
    public enum Pursuing
    {
        BS, MS, PhD
    }

    public class Application
    {
        public Pursuing pursuing { get; set; }

        public string? Dept { get; set; }

        public int hours { get; set; }

        public bool avaliableBeforeSchoo { get; set; }

        public int semestersCompleted { get; set; }

        public string? transferSchool { get; set; }

        public string? linkedInURL { get; set; }

        public string? resumeFileName { get; set; }

        public DateTime Creation { get; set; }

        public DateTime lastModified { get; set; }

        public int Id { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Grade Point Average",
            Description = "Please enter a GPA between 0 and 4.0",
            ShortName = "GPA")]
        [Range(0,5)]
        public double GPA { get; set; }

        public int UserID { get; set; }

        public TAUser TAUser { get; set; } = null!;

    
    }
}
