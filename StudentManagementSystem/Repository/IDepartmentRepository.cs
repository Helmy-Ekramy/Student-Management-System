using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Repository
{
    public interface IDepartmentRepository
    {
        public List<DepartmentsGetAllModel> GetAll();

        public void Add(Department neww);

        public void Update(Department neww);

        public void Delete(int id);

        public Department GetById(int id);



        public void Save();
        
    }
}
