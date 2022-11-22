using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using TAApplication.Data;
using TAApplication.Models;

namespace TAApplication.Controllers
{
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Slots
        public async Task<IActionResult> Index(string? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }
            var test = _context.Slot.Where(o => o.TAUser.Unid == id).ToList();

            return View(await _context.Slot.ToListAsync());
        }

        // GET: Slots
        public async Task<IActionResult> GetSchedule(string? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }
            var test = _context.Slot.Where(o => o.TAUser.Unid == id).ToList();
            return Ok(test);
        }
        [HttpPost]
        public async Task<IActionResult> SetSchedule(string id, string schedule)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }

            bool[] sched = JsonConvert.DeserializeObject<bool[]>(schedule);

            var userSchedule = _context.Slot.Where(o => o.TAUser.Unid == id).ToList();
            for (int i = 0; i < userSchedule.Count; i++)
            {
                userSchedule[i].open = sched[i];
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Time,open")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Time,open")] Slot slot)
        {
            if (id != slot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.ID))
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
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slot'  is null.");
            }
            var slot = await _context.Slot.FindAsync(id);
            if (slot != null)
            {
                _context.Slot.Remove(slot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.Slot.Any(e => e.ID == id);
        }
    }
}
