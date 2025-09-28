using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
namespace StudentManagementSystem.Repository
{
    public class StudentRepository:IStudentRepository
    {
        // CRUD
        StudentManagementContext db;

        public StudentRepository(StudentManagementContext _db)
        {
            //db = new StudentManagementContext();
            db = _db;
        }

        public List<StudentGetAllModel> GetAll()
        {
            return db.Students.Select(s => new StudentGetAllModel { Id = s.Id, Name = s.Name, Email = s.Email, DeptName = s.Department.Name, DateOfBirth = s.DateOfBirth }).ToList();

        }

        public void Add(Student neww)
        {
            db.Students.Add(neww);
        }
        public void Update(Student neww)
        {
            db.Students.Update(neww);
        }
        public void Delete(int id)
        {
            var student = GetById(id);
            db.Students.Remove(student);
        }

        public Student GetById(int id)
        {
            return db.Students.Find(id);
        }

        public StudentDetailsModel GetDetailsById(int id)
        {
            return db.Students
                 .Where(s => s.Id == id)
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
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}
