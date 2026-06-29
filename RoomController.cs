using Microsoft.AspNetCore.Mvc;
using HostelManagement.Models;

namespace HostelManagement.Controllers
{
    public class RoomController : Controller
    {

        RoomDAL obj = new RoomDAL();



        // Add Room GET
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }



        // Add Room POST
        [HttpPost]
        public IActionResult AddRoom(Room rm)
        {

            int i = obj.InsertRoom(rm);


            if (i > 0)
            {
                return RedirectToAction("RoomList");
            }
            else
            {
                ViewBag.msg = "Failed";
                return View();
            }

        }




        // Room List
        public IActionResult RoomList()
        {

            var data = obj.GetRooms();

            return View(data);

        }





        // Edit Room GET
        [HttpGet]
        public IActionResult EditRoom(int id)
        {

            Room rm = obj.GetRoomById(id);

            return View(rm);

        }





        // Edit Room POST
        [HttpPost]
        public IActionResult EditRoom(Room rm)
        {

            int i = obj.UpdateRoom(rm);


            if (i > 0)
            {
                return RedirectToAction("RoomList");
            }


            ViewBag.msg = "Update Failed";

            return View(rm);

        }






        // Delete Room

        public IActionResult DeleteRoom(int id)
        {

            obj.DeleteRoom(id);


            return RedirectToAction("RoomList");

        }


    }
}
