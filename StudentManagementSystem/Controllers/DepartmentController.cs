using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Controllers
{

    //[Authorize]
    public class DepartmentController : Controller
    {
        StudentManagementContext db=new StudentManagementContext();


        public IActionResult TestDeptName(string Name)
        {
            StudentManagementContext db = new StudentManagementContext();

            var dept = db.Departments.FirstOrDefault(a => a.Name == Name);
            if (dept == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult Edit(int id)
        {
           var dept = db.Departments.Find(id);
           return View(dept);   
        }

        public IActionResult EditDept(Department dept)
        {

                db.Departments.Update(dept);
                db.SaveChanges();

                return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int id)
        {
           var dept= db.Departments.Find(id);
            db.Departments.Remove(dept); 
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddDepartment(Department neww)
        {
                    db.Departments.Add(neww);
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

            var depts=db.Departments.Include(d=>d.Students).ToList();

            if(depts!=null)
            {
            return View(depts);
            }
            else
            {
                return View("canNot", "There is no Depatrtment Yet");
            }

        }
    }
}
