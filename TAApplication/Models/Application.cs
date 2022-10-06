using EllipticCurve.Utils;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using TAApplication.Areas.Data;

namespace TAApplication.Models
{
    public enum Pursuing
    {
        BS, MS, PhD
    }

    public class Application : ModificationTracking
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Degree Being Pursued",
            Description = "Please select your degree.",
            Prompt = "BS",
            ShortName = "Degree")]
        public Pursuing pursuing { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Degree Department",
            Description = "Please enter the department your degree is in.",
            Prompt = "CS",
            ShortName = "Dept")]
        [DataType(DataType.Text)]
        public string? Dept { get; set; }


        [Microsoft.Build.Framework.Required]
        [Display(Name = "Grade Point Average",
            Description = "Please enter a GPA between 0 and 4.0",
            Prompt = "3.4",
            ShortName = "GPA")]
        [Range(0, 5)]
        public double GPA { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Number of Hours Available",
            Description = "Please enter the number of hours you can work.",
            Prompt = "10",
            ShortName = "Hours")]
        [Range(5, 20)]
        public int hours { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Available Week Before School",
            Description = "Are you available the week before school starts?",
            ShortName = "Avail Before")]
        public bool avaliableBeforeSchoo { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Semesters Completed at Utah",
            Description = "Please enter the number of semesters you have completed at Utah.",
            Prompt = "4",
            ShortName = "Semesters at Utah")]
        [Range(0, int.MaxValue)]
        public int semestersCompleted { get; set; }

        [Display(Name = "Personal Statement",
            Description = "If desired, add a personal statement.",
            Prompt = "I would be a great TA...",
            ShortName = "Statement")]
        [StringLength(50000)]
        public string? personalStatement { get; set; }

        [Display(Name = "School Transfered From",
            Description = "If you have transferred, please enter the school.",
            Prompt = "SLCC",
            ShortName = "Transfer School")]
        [StringLength(150)]
        public string? transferSchool { get; set; }

        [Display(Name = "URL To LinkedIn",
            Description = "If you have a LinkedIn profile, please add it.",
            Prompt = "URL",
            ShortName = "LinkedIn")]
        [Url]
        public string? linkedInURL { get; set; }

        [Display(Name = "Resume File",
            Description = "Please add a resume if you desire.",
            Prompt = "my_resume.pdf",
            ShortName = "Resume")]
        public string? resumeFileName { get; set; }

        public int ID { get; set; }

        public TAUser TAUser { get; set; } = null!;
    }
}
