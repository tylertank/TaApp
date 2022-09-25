﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
