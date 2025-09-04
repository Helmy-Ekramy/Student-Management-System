using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{


    //[Authorize]

    public class InstructorController : Controller
    {
        StudentManagementContext db = new StudentManagementContext();




        public IActionResult Edit(int id)
        {
            var inst = db.Instructors.Include(i=>i.OfficeAssignment).FirstOrDefault(i=>i.Id==id);
            return View(inst);
        }

        public IActionResult EditInstructor(Instructor instructor)
        {

            db.Instructors.Update(instructor);
            db.SaveChanges();

            return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int id)
        {
            var inst = db.Instructors.Find(id);
            db.Instructors.Remove(inst);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddInstructor(Instructor neww)
        {
            db.Instructors.Add(neww);
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
            var instructors=db.Instructors.Include(i=>i.OfficeAssignment).ToList();
            if (instructors != null)
                return View(instructors);
            else
                return View("CanNot","There is Instructors yet !");
        }
    }
}
