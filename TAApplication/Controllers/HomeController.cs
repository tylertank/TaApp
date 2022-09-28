/*< !--
    Author:    Cole Hanlon
Partner:   Tyler Harkness
Date: 9 / 27 / 2022
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.

    I, Cole Hanlon & Tyler Harkness, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.Any references used in the completion of the assignment are cited in my README file.

  File Contents

     This HomeController.cs file contains all links to home webpages with the correct permissions. 
    If you do not have permission to view a specific page you will be greeted with an error page. 
-->*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TAApplication.Models;

namespace TAApplication.Controllers
{
    [Authorize(Roles = "Administrator, Professor, Applicant")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// returns the home page to all users
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// returns the applicantList page for administrators and professors
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Professor")]
        public IActionResult ApplicantList()
        {
            return View();
        }
        /// <summary>
        /// returns the application create page for anyone that is signed in
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Applicant, Administrator, Professor")]
        public IActionResult ApplicationCreate()
        {
            return View();
        }

        /// <summary>
        /// returns the application details page for anyone that is signed in
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, Professor, Applicant")]
        public IActionResult ApplicationDetails()
        {
            return View();
        }
        /// <summary>
        /// returns the privacy page for all signed in users
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}