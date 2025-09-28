using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Repository
{
    public interface IStudentRepository
    {
        public List<StudentGetAllModel> GetAll();


        public void Add(Student neww);

        public void Update(Student neww);

        public void Delete(int id);

        public Student GetById(int id);


        public StudentDetailsModel GetDetailsById(int id);

        public void Save();
        


    }
}
