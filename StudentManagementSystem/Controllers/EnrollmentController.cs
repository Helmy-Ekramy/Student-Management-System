using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {

        StudentManagementContext db=new StudentManagementContext();

        public IActionResult OpenGrades(int id)
        {

            //var enrollments=db.Enrollments.Include(e=>e.Course).Where(e=>e.StudentId==studentId).ToList();
            //ViewBag.StudentId = studentId;
            var student=db.Students.Include(s=>s.Enrollments).ThenInclude(e=>e.Course).FirstOrDefault(s=>s.Id==id);
            return View(student);
        }

        public IActionResult EditGrades(Student s)
        {
            int studentId=s.Id;

            foreach (var item in s.Enrollments)
            {
            db.Enrollments.Update(item);
            db.SaveChanges();
            }

            return RedirectToAction("Details", "Student", new { id = studentId });

        }

        public IActionResult Edit(int id)
        {
          
            var enrollment=db.Enrollments.Find(id);

            var lastCourses = db.Enrollments.Where(e => e.StudentId == enrollment.StudentId).Select(e => e.Course).ToList();
            var allCourses = db.Courses.ToList();
            var courses = allCourses.Except(lastCourses);
            ViewBag.courses = courses;
            ViewBag.studentId = enrollment.StudentId;


            return View(enrollment);
        }

        public IActionResult EditEnrollment(Enrollment enrollment)
        {

            db.Enrollments.Update(enrollment);
            db.SaveChanges();

            return RedirectToAction("Details", "Student", new { id = enrollment.StudentId });

        }

        public IActionResult Delete(int id)
        {

            var e = db.Enrollments.Find(id);
            db.Enrollments.Remove(e);
            db.SaveChanges();
            //return RedirectToAction("Details", "Student", new {id=e.StudentId});
            var enrollments = db.Enrollments.Where(en => en.StudentId == e.StudentId).Select(e => new EnrollmentDetailsModel
            {
                Id = e.Id,
                CourseName = e.Course.Name,
                Credits = e.Course.Credits,
                Grade = e.Grade,
                result = e.Grade != null ? (e.Grade >= 50 ? "Pass" : "Fail") : e.result,
                resultClass = e.Grade != null ? (e.Grade >= 50 ? "text-success" : "text-danger") : e.resultClass


            })
            .ToList();

          
            return PartialView("_DeleteEnrollPartial", enrollments);
        }


        public IActionResult Create(int id)
        {
            var lastCourses=db.Enrollments.Where(e=>e.StudentId==id).Select(e=>e.Course).ToList();
            var allCourses=db.Courses.ToList();
            var courses=allCourses.Except(lastCourses);
            ViewBag.courses=courses;


            ViewBag.studentId=id;
            return View();
        }
        public IActionResult Enroll(Enrollment en)
        {


            if (en != null)
            {
                var student = db.Students.Find(en.StudentId);
                if(student.Enrollments.IsNullOrEmpty())
                {
                    student.Enrollments = new List<Enrollment> { en};
                }
                else
                {
                    student.Enrollments.Add(en);
                }

                db.SaveChanges();

                return RedirectToAction("Details", "Student",new{ id=en.StudentId });
            }
            else
                return Content("Error");
        }
    }
}
