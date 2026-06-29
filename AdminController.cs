using Microsoft.AspNetCore.Mvc;
using HostelManagement.Models;

namespace HostelManagement.Controllers
{
    public class AdminController : Controller
    {
        AdminDAL obj = new AdminDAL();


        // GET: Admin/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Admin ad)
        {
            int i = obj.AdminRegister(ad);

            if (i > 0)
            {
                ViewBag.msg = "Registration Successful";
            }
            else
            {
                ViewBag.msg = "Registration Failed";
            }

            return View();
        }
    }

}

