using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLabPractice.Repository.Repository;
using MvcLabPractice.Model.Model;

namespace MvcLabPractice.BLL.BLL
{
    public class DepartmentManager
    {
        DepartmentRepository _departmentRepository = new DepartmentRepository();
        public bool Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public bool Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }
        public bool Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
