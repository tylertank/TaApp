/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      11/22/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *   This file contains controls for student/applicant availability. This file returns a view for the applicant, showing their
 *   selected availability. It also includes endpoints for control by JavaScript methods running from the view.
 */

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
    /// <summary>
    /// Defines methods to control an applicant's availability
    /// </summary>
    [Authorize(Roles = "Applicant")]
    public class SlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlotsController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Returns the view of an applicants availability 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// Returns a list of the availability for the input student ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetSchedule(string? id)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }

            try
            {
                var test = _context.Slot.Where(o => o.TAUser.Unid == id).ToList();
                return Ok(test);
            }
            catch (Exception)
            {
                return BadRequest("Fail");
            }
        }

        /// <summary>
        /// Allows for updating a student's availability. Updates the student with the input ID, and sets
        /// all values in database according to the schedule parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SetSchedule(string id, string schedule)
        {
            if (id == null || _context.Slot == null)
            {
                return NotFound();
            }
            try
            {
                bool[] sched = JsonConvert.DeserializeObject<bool[]>(schedule);

                var userSchedule = _context.Slot.Where(o => o.TAUser.Unid == id).ToList();
                for (int i = 0; i < userSchedule.Count; i++)
                {
                    userSchedule[i].open = sched[i];
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Fail");
            }
        }
    }
}
