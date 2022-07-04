using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core.Repostories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> EmployeesWithProjects();

        IEnumerable<Employee> EmployeesWithProjectsWithManagers();

        Employee GetEmployeesWithProjectWithManagersById(int? id);

        List<int> GetAllEmployeesIds(IEnumerable<Employee> employees);

        Employee GetAllEmployeesPerProjectPerManagerById(int? id);

        void Add(Employee emp, List<int> managerIds);

        void Edit(Employee emp, Employee newEmp);


    }
}
