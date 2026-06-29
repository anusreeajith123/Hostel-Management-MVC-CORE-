using Microsoft.AspNetCore.Mvc;
using HostelManagement.Models;

namespace HostelManagement.Controllers
{
    public class LoginController : Controller
    {
        LoginDAL obj = new LoginDAL();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Admin ad)
        {
            if (ad.UserName == null)
            {
                return Content("Username is NULL");
            }

            if (ad.Password == null)
            {
                return Content("Password is NULL");
            }

            bool status = obj.AdminLogin(ad);

            if (status)
            {
                TempData["Success"] = "Login Successful";
                return RedirectToAction("AddStudent", "Student");
            }

            ViewBag.msg = "Invalid Username or Password";
            return View();
        }
    }
    
}
