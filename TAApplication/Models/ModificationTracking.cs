/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      10/7/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      This file defines modification tracking for use in database items.
*/

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
