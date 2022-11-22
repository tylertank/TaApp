using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using TAApplication.Data;
using TAApplication.Models;

namespace TAApplication.Controllers
{
    [Authorize(Roles = "Applicant")]
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Slots
        public async Task<IActionResult> Index()
        {
            return View();
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
    }
}
