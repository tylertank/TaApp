/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      9/27/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *  The base user for our ASP authentication system.
 */
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
