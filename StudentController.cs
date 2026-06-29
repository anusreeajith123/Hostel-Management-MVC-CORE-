using Microsoft.AspNetCore.Mvc;
using HostelManagement.Models;

namespace HostelManagement.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL obj = new StudentDAL();

        // Add Student GET
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }


        // Add Student POST
        [HttpPost]
        public IActionResult AddStudent(Student st)
        {
            int i = obj.InsertStudent(st);

            if (i > 0)
            {
                return RedirectToAction("StudentList");
            }
            else
            {
                ViewBag.msg = "Failed";
                return View();
            }
        }


        // Student List
        public IActionResult StudentList()
        {
            List<Student> list = obj.GetStudents();

            return View(list);
        }


        // Edit Student GET
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student st = obj.GetStudentById(id);

            return View(st);
        }


        // Edit Student POST
        [HttpPost]
        public IActionResult EditStudent(Student st)
        {
            int i = obj.UpdateStudent(st);

            if (i > 0)
            {
                return RedirectToAction("StudentList");
            }
            else
            {
                ViewBag.msg = "Update Failed";
                return View(st);
            }
        }


        // Delete Student
        public IActionResult DeleteStudent(int id)
        {
            int i = obj.DeleteStudent(id);

            if (i > 0)
            {
                return RedirectToAction("StudentList");
            }
            else
            {
                ViewBag.msg = "Delete Failed";
                return RedirectToAction("StudentList");
            }
        }

    }
}

