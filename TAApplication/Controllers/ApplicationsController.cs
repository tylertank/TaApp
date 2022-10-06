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
    [Authorize(Roles = "Applicant, Administrator, Professor")]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TAUser> _um;

        public ApplicationsController(ApplicationDbContext context, UserManager<TAUser> um)
        {
            _context = context;
            _um = um;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Applications
        [Authorize(Roles = "Administrator, Professor")]
        public async Task<IActionResult> List()
        {
              return View(await _context.Applications
                  .Include(o => o.TAUser)
                  .ToListAsync());
        }

        [Authorize(Roles = "Administrator, Professor, Applicant")]
        // GET: Applications/Details/5
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

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Applications/Edit/5

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


                    // GET: Applications/Delete/5
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

        // POST: Applications/Delete/5
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

        private bool ApplicationExists(int id)
        {
          return _context.Applications.Any(e => e.ID == id);
        }
    }
}
