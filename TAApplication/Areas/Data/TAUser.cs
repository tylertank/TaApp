﻿/*< !--
    Author:    Cole Hanlon
Partner:   Tyler Harkness
Date: 9 / 27 / 2022
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.

    I, Cole Hanlon & Tyler Harkness, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.Any references used in the completion of the assignment are cited in my README file.

  File Contents

   The base user for our ASP authentication system.
-->*/
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
        public string? ReferredTo { get; set; }
    }
}
