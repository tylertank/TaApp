
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TAApplication.Models;

/*Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:     10/7 / 2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      This OldController.cs file contains all links to the old home webpages with the correct permissions. 
 *      If you do not have permission to view a specific page you will be greeted with an error page. 
*/
namespace TAApplication.Controllers
{
    [Authorize]
    public class OLDController : Controller
    {
        private readonly ILogger<OLDController> _logger;

        public OLDController(ILogger<OLDController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// returns the applicantList page for administrators and professors
        /// </summary>
        /// <returns></returns>
       
        public IActionResult ApplicantList()
        {
            return View();
        }
        /// <summary>
        /// returns the application create page for anyone that is signed in
        /// </summary>
        /// <returns></returns>
     
        public IActionResult ApplicationCreate()
        {
            return View();
        }

        /// <summary>
        /// returns the application details page for anyone that is signed in
        /// </summary>
        /// <returns></returns>
      
        public IActionResult ApplicationDetails()
        {
            return View();
        }
    }
}
