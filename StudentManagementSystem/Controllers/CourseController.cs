using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        StudentManagementContext db=new StudentManagementContext();

         public IActionResult Edit(int id)
        {
            var course = db.Courses.Find(id);
            return View(course);
        }

        public IActionResult Editcourse(Course course)
        {

            db.Courses.Update(course);
            db.SaveChanges();

            return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int id)
        {
            var course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddCourse(Course neww)
        {
            db.Courses.Add(neww);
            db.SaveChanges();
            return RedirectToAction("GetAll");
            //if (ModelState.IsValid)
            //{


            //}
            ////return View("Create");
            //return Content("????");
        }
        public IActionResult GetAll()

        {

            var courses = db.Courses.ToList();

            if (!courses.IsNullOrEmpty())
            {
                return View(courses);
            }
            else
            {
                return View("canNot", "There is no Cousres Yet");
            }

        }

    }
}
