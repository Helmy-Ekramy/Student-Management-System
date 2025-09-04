using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Controllers
{
    //[Route("student")]
    public class StudentController : Controller
    {
        StudentManagementContext db = new StudentManagementContext();

        //[Route("data/{id:int}")]
        public IActionResult Details(int id)
        {
            var student = db.Students
                .Where(s=>s.Id==id)
                .Select(s => new StudentDetailsModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth,
                    DepartmentName = s.Department.Name,
                    StudentImage = s.StudentImage,
                    Enrollments = s.Enrollments.Select(e => new EnrollmentDetailsModel
                    {
                        Id = e.Id,
                        CourseName = e.Course.Name,
                        Credits = e.Course.Credits,
                        Grade = e.Grade,
                        result = e.Grade != null ? (e.Grade >= 50 ? "Pass" : "Fail") : e.result,
                        resultClass = e.Grade != null ? (e.Grade >= 50 ? "text-success" : "text-danger") : e.resultClass

                    }
                    ).ToList()
                }).FirstOrDefault();
                
            return View(student);
        }





     
    
        public IActionResult TestDOB( DateTime DateOfBirth)
        {
            int age =DateTime.Now.Year- DateOfBirth.Year ;
            if(DateOfBirth > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age >= 18 && age <= 25) 
            {
                return Json(true);
            }
            return Json(false);
        }

        //[Route("getAll")]
        public IActionResult GetAll(string search)
        {

            var students = db.Students.Include(s=>s.Department).ToList();

            if (students != null)
            {
                if(!search.IsNullOrEmpty())
                {
                    students=students.Where(s=>s.Name.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
                }
                return View(students);
            }
            else
            {
                return View("canNot", "There is no Depatrtment Yet");
            }

        }


        public IActionResult Create()
        {

            ViewBag.depts=db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student neww, IFormFile img)
        {
            db.Students.Add(neww);
            db.SaveChanges();

            if (img != null && img.Length > 0)
            {
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "students");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                var fileName =neww.Id.ToString()+ Path.GetExtension(img.FileName);
                var filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }

                neww.StudentImage = "/assets/img/students/" + fileName;
              db.SaveChanges();
            }


            return RedirectToAction("GetAll");
        }


        public IActionResult Delete(int id)
        {
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.depts = db.Departments.ToList();

            var student = db.Students.Find(id);
            return View(student);
        }

        public IActionResult EditStudent(Student st)
        {

            db.Students.Update(st);
            db.SaveChanges();

            return RedirectToAction("GetAll");

        }

    }
}
