using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        StudentManagementContext db;

        public DepartmentRepository(StudentManagementContext _db)
        {
            //db = new StudentManagementContext();
            db = _db;
        }

        public List<DepartmentsGetAllModel> GetAll()
        {
            return db.Departments.Select(s => new DepartmentsGetAllModel { Id = s.Id, Name = s.Name, StudentCount=s.Students.Count}).ToList();

        }

        public void Add(Department neww)
        {
            db.Departments.Add(neww);
        }
        public void Update(Department neww)
        {
            db.Departments.Update(neww);
        }
        public void Delete(int id)
        {
            var student = db.Departments.Find(id);
            db.Departments.Remove(student);
        }

        public Department GetById(int id)
        {
            return db.Departments.Find(id);
        }

  
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
