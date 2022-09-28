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

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Roles()
        {
            return View();
        }

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

            return BadRequest();
        }
    }
}
