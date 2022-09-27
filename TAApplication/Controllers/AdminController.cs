using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TAApplication.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        public string doit(int id)
        {
            return $"You sent me id: {id}";
        }

    }
}
