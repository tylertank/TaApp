using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAApplication.Data;
using TAApplication.Models;

namespace TAApplication.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
              return View(await _context.Application.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Create([Bind("pursuing,Dept,hours,avaliableBeforeSchoo,semestersCompleted,transferSchool,linkedInURL,resumeFileName,Creation,lastModified,Id,GPA,UserID")] Application application)
        {
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
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pursuing,Dept,hours,avaliableBeforeSchoo,semestersCompleted,transferSchool,linkedInURL,resumeFileName,Creation,lastModified,Id,GPA,UserID")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Application == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Application'  is null.");
            }
            var application = await _context.Application.FindAsync(id);
            if (application != null)
            {
                _context.Application.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
          return _context.Application.Any(e => e.Id == id);
        }
    }
}
