using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace TAApplication.Models
{
    public class ModificationTracking
    {

        [Required]
        [ScaffoldColumn(false)]
        public DateTime CreationDate{ get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public DateTime ModificationDate { get; set; }


        [ScaffoldColumn(false)]
        public string? CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public string? ModifiedBy { get; set; }

    }
}
