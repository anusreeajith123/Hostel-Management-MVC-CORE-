using Microsoft.AspNetCore.Mvc;
using HostelManagement.Models;

namespace HostelManagement.Controllers
{
    public class AllocationController : Controller
    {
        AllocationDAL obj = new AllocationDAL();



        // Allocation List
        public IActionResult AllocationList()
        {
            var data = obj.GetAllocation();

            return View(data);
        }



        // Open Allocation Page
        [HttpGet]
        public IActionResult AddAllocation()
        {
            return View();
        }



        // Insert Allocation
        [HttpPost]
        public IActionResult AddAllocation(Allocation a)
        {
            a.AllocationDate = DateTime.Now;
            int i = obj.InsertAllocation(a);


            if (i > 0)
            {
                return RedirectToAction("RoomList", "Room");
            }


            ViewBag.msg = "Allocation Failed";


            return View();

        }
    }
}
