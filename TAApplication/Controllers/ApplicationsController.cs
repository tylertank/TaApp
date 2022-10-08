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
 *   This ApplicationsCcontroller.cs file contains permissions and redirects relating to the application portion of the website. 
 *   creating, deleting, viewing and editing applications. 
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAApplication.Areas.Data;
using TAApplication.Data;
using TAApplication.Models;


namespace TAApplication.Controllers
{
    /// <summary>
    /// Sets up permissions and controls all web pages regarding applications.
    /// </summary>
    [Authorize(Roles = "Applicant, Administrator, Professor")]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TAUser> _um;

        /// <summary>
        /// Stores the database and usermanager from constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="um"></param>
        public ApplicationsController(ApplicationDbContext context, UserManager<TAUser> um)
        {
            _context = context;
            _um = um;
        }

        /// <summary>
        /// Returns admin home view
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// gets a list of all the applications.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Professor")]
        public async Task<IActionResult> List()
        {
              return View(await _context.Applications
                  .Include(o => o.TAUser)
                  .ToListAsync());
        }

        /// <summary>
        /// Displays the application details for the given application ID, 
        /// if the current user has the correct permissions.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Professor, Applicant")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.Include(o => o.TAUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            if(User.Identity.Name != application.TAUser.UserName && !User.IsInRole("Professor") && !User.IsInRole("Administrator"))
            {
                return Forbid();
            }

            return View(application);
        }

       /// <summary>
       /// redirects the user's webbrowser to the details page when they have already created an application.
       /// or displays a blank application.
       /// </summary>
       /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var application = await _context.Applications.Include(o => o.TAUser)
                .FirstOrDefaultAsync(m => m.TAUser.UserName == User.Identity.Name);

            if (application != null)
            {
               return RedirectToAction("Details", new { id = application.ID });
            }

            return View();
        }

        /// <summary>
        /// creates an application and saves it to the database.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Applicant, Administrator, Professor")]
        public async Task<IActionResult> Create([Bind("pursuing,Dept,GPA,hours,avaliableBeforeSchoo,semestersCompleted,personalStatement,transferSchool,linkedInURL,resumeFileName")] Application application)
        {
            ModelState.Remove("TAUser");
            application.TAUser = await _um.GetUserAsync(User);
      
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = application.ID });
            }
            return View(application);
        }

        
        /// <summary>
        /// Finds the application in the database and displays it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        /// <summary>
        /// Retrieves the application from the database and puts the new information into it and saves it to the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator,Applicant")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null) { return BadRequest(); }
            var applicationToUpdate = _context.Applications
                                    .Where(o => o.ID == id).Include(o => o.TAUser).FirstOrDefault();
            if (applicationToUpdate != null)
            {
                if (await TryUpdateModelAsync<Application>(applicationToUpdate, "",
                   s => s.pursuing,
                   s => s.Dept,
                   s => s.GPA,
                   s => s.hours,
                   s => s.semestersCompleted,
                   s => s.personalStatement,
                   s => s.transferSchool,
                   s => s.linkedInURL,
                   s => s.resumeFileName))
                {
                    try {
                        _context.SaveChanges();
                        return RedirectToAction("Details", new { id = applicationToUpdate.ID });
                    }
                    catch (DataException)
                    {
                        return View(applicationToUpdate);
                    }
                }
            }

            return BadRequest();
        }


        /// <summary>
        /// finds the application in the database and displays it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator,Applicant")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        /// <summary>
        /// confirms that the database contains an application with the given ID and deletes the application. 
        /// Returns an error if the application is not found or the database has no applications.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Applications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Applications'  is null.");
            }
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// checkes if the application is in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ApplicationExists(int id)
        {
          return _context.Applications.Any(e => e.ID == id);
        }
    }
}
