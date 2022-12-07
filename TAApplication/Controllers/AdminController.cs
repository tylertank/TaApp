﻿/**
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
 *   This AdminController.cs file contains all contents to change the roles for a given user, and render the admin roles page.
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using TAApplication.Areas.Data;
using TAApplication.Data;

namespace TAApplication.Controllers
{
    /// <summary>
    /// Defines an admin controller, only an admin has access to these webpages and functionality.
    /// </summary>
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private UserManager<TAUser> um;
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Automatically bring in the user manager
        /// </summary>
        /// <param name="userManager"></param>
        public AdminController(UserManager<TAUser> userManager, ApplicationDbContext Context )
        {
            um = userManager; 
            _context = Context;
        }

        /// <summary>
        /// the default homepage for admin not in use
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// returns the roles page for admin, can edit all user permissiosn from this page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Roles()
        {
            return View();
        }


        public async Task<IActionResult> EnrollmentTrends()
        {
            return View(await _context.Course.ToListAsync());
        }

        public async Task<IActionResult> GetEnrollmentData(DateTime start, DateTime end, string dept, int courseNum)
        {
            var enrollments = _context.Enrollments.Where(e => e.enrolledTime.Date >= start.Date && e.enrolledTime.Date <= end.Date 
                                                           && e.course.department == dept && e.course.courseNumber == courseNum);
           
            return View(enrollments.ToList());
        }


        /// <summary>
        /// Takes in the users ID and toggles the role on or off A
        /// A user can only have one role at a time.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Change_Role(string user_id, string role)
        {
            TAUser user = await um.FindByIdAsync(user_id);
            var currentRoles = await um.GetRolesAsync(user);

            if (currentRoles.Contains(role))
            {
                await um.RemoveFromRoleAsync(user, role);
                return Ok(new { success = true, message = "removed role!" });
            }
            else
            {
                if(currentRoles.Count > 0)
                {
                    return BadRequest(new { success = false, message = "user can only have one role!" });
                }
                await um.AddToRoleAsync(user, role);
                return Ok(new { success = true, message = "added role!" });
            }

        }
    }
}
