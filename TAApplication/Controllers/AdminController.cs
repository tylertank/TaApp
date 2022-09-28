/*< !--
    Author:    Cole Hanlon
Partner:   Tyler Harkness
Date: 9 / 27 / 2022
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.

    I, Cole Hanlon & Tyler Harkness, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.Any references used in the completion of the assignment are cited in my README file.

  File Contents

     This AdminController.cs file contains all contents to change the roles for a given user, and render the admin roles page.
-->*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using TAApplication.Areas.Data;

namespace TAApplication.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private UserManager<TAUser> um;

        public AdminController(UserManager<TAUser> userManager)
        {
            um = userManager; 
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
