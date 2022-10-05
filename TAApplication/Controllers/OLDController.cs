using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TAApplication.Models;

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
