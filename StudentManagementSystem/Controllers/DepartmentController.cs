using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Controllers
{

    //[Authorize]
    public class DepartmentController : Controller
    {

            IDepartmentRepository DepartmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            //DepartmentRepository = new DepartmentRepository();
            DepartmentRepository = departmentRepository;
        }

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
            var dept = DepartmentRepository.GetById(id);
           return View(dept);   
        }

        public IActionResult EditDept(Department dept)
        {

            DepartmentRepository.Update(dept);
            DepartmentRepository.Save();

                return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int id)
        {
            DepartmentRepository.Delete(id);
            DepartmentRepository.Save();
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddDepartment(Department neww)
        {
                    DepartmentRepository.Add(neww);
            DepartmentRepository.Save();
                return RedirectToAction("GetAll");
            //if (ModelState.IsValid)
            //{


            //}
            ////return View("Create");
            //return Content("????");
        }
        public IActionResult GetAll()
        {

            var depts=DepartmentRepository.GetAll();

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
