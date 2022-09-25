using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace TAApplication.Areas.Data
{

    [Index(nameof(Unid), IsUnique = true)]
    public class TAUser : IdentityUser
    {
        public string Unid { get; set; }
        public string FullName { get; set; }
        public string ReferredTo { get; set; }
    }
}
