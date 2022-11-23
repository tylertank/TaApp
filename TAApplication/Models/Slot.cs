using System;

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using TAApplication.Areas.Data;

namespace TAApplication.Models
{
    public class Slot : ModificationTracking
    {
        public Slot()
        {

        }
        public Slot(TAUser tAUser, int? time, bool open)
        {    
            TAUser = tAUser;
            Time = time;
            this.open = open;
        }
    
        public int ID { get; set; }
      
        public TAUser TAUser { get; set; } = null!;

        [Microsoft.Build.Framework.Required]
        public int? Time { get; set; }

        [Microsoft.Build.Framework.Required]
        public bool open { get; set; }
    }
}