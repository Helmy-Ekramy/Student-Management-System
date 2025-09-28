using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;
using StudentManagementSystem.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagementSystem.Controllers
{
    //[Route("student")]
    public class StudentController : Controller
    {
        IStudentRepository studentRepository;
        IDepartmentRepository departmentRepository;
        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            //studentRepository = new StudentRepository();    
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
        }


        //[Route("data/{id:int}")]
        public IActionResult Details(int id)
        {
            //

            var student=studentRepository.GetDetailsById(id);
                
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

        [Authorize]
        public IActionResult GetAll(string search="")
        {
            //

            //var students = db.Students.Include(s=>s.Department).ToList();

            var students = studentRepository.GetAll();
            


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
            //
            //DepartmentRepository departmentRepository = new DepartmentRepository();

            ViewBag.depts=departmentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student neww, IFormFile img)
        {
            //
            //db.Students.Add(neww);
            //db.SaveChanges();

            studentRepository.Add(neww);
            studentRepository.Save();

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
              //db.SaveChanges();
              studentRepository.Save();
            }


            return RedirectToAction("GetAll");
        }


        public IActionResult Delete(int id)
        {
            //
            //var st = db.Students.Find(id);
            //db.Students.Remove(st);
            //db.SaveChanges();

            studentRepository.Delete(id);
            studentRepository.Save();
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id)
        {
            //

            //DepartmentRepository departmentRepository = new DepartmentRepository();

            ViewBag.depts = departmentRepository.GetAll();

            //var student = db.Students.Find(id);
            var student = studentRepository.GetById(id);

            return View(student);
        }

        public IActionResult EditStudent(Student st)
        {
            //
            //db.Students.Update(st);
            //db.SaveChanges();
            studentRepository.Update(st);
            studentRepository.Save();
            return RedirectToAction("GetAll");

        }

    }
}
