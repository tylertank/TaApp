/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      10/24/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      This file contains all data attributes for courses.
*/
namespace TAApplication.Models {

    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml.Linq;

    public class Course : ModificationTracking
    {
        
        public int ID { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Semester Offered",
            Description = "The semester the class is offered.",
            Prompt = "Spring",
            ShortName = "semester")]
        [DataType(DataType.Text)]
        public string? semesterOffered { get; set; }
  
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Year Offered",
            Description = "The year the class is offered.",
            Prompt = "2022",
            ShortName = "year")]
        [Range(1900,2100)]
        public int yearOffered { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Class Title",
            Description = "Title of the class.",
            Prompt = "Algorithms",
            ShortName = "Class")]
        [DataType(DataType.Text)]
        public string? title { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Class Department",
            Description = " department the class is in.",
            Prompt = "CS",
            ShortName = "Dept")]
        [DataType(DataType.Text)]
        public string? department { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Course Number",
            Description = "Course Number",
            Prompt = "4150",
            ShortName = "number")]
        [Range(0, 10000)]
        public int courseNumber { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Course Section",
            Description = "The section the course is in",
            Prompt = "001",
            ShortName = "section")]
        [Range(0,10000)]
        public int section { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Class Description",
            Description = "Desription of the class",
            Prompt = "This class teaches you about advanced algorithms",
            ShortName = "description")]
        [DataType(DataType.Text)]
        public string? description { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Professor uID",
            Description = "uID of the professor teaching the class",
            Prompt = "u1111111",
            ShortName = "pID")]
        [RegularExpression("^u[0-9]{7}")]
        public string? professorUID { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Professor Name",
            Description = "Name of the professor in charge of the class.",
            Prompt = "Daniel Kopta",
            ShortName = "professor name")]
        [DataType(DataType.Text)]
        public string? professorName { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Days / Time",
            Description = "Day and time of the class",
            Prompt = "M/W 5:00-6:00",
            ShortName = "day and time")]
        [DataType(DataType.Text)]
        public string? dayAndTimeOffered { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Location",
            Description = "Where the class is held",
            Prompt = "Web L104",
            ShortName = "location")]
        [DataType(DataType.Text)]
        public string? location { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Credit Hours",
            Description = "Credit hours that the class is worth",
            Prompt = "3",
            ShortName = "credits")]
        [Range(0, 6)]
        public int creditHours { get; set; }
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Enrollment",
            Description = "Amount of students currently enrolled in the class",
            Prompt = "150",
            ShortName = "enrolled")]
        [Range(0, 1000)]
        public int enrollment { get; set; }
        [Display(Name = "Class Notes",
        Description = "any administrative notes about this class",
        Prompt = "we need another TA",
        ShortName = "notes")]
        [DataType(DataType.Text)]
        public string? Note { get; set; }


    }
}

