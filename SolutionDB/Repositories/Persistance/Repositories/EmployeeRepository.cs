using Entities;
using MyDatabase;
using Repositories.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Persistance.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(MyDBContext context) : base(context)
        {
           
        }

        public void Add(Employee emp, List<int> managerIds)
        {
            foreach (var id in managerIds)
            {
                var manager = db.Managers.Find(id);
                if (manager != null)
                {
                    emp.Managers.Add(manager);
                }
            }

            db.Entry(emp).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Employee emp, Employee newEmp)
        {
            if (emp == null)
            {
                throw new ArgumentException("Emp Not Found");
            }
            // Step 1 Mapping
            emp.FirstName = newEmp.FirstName;
            emp.LastName = newEmp.LastName;
            emp.Salary = newEmp.Salary;
            emp.DateOfBirth = newEmp.DateOfBirth;
            emp.HireDate = newEmp.HireDate;
            emp.Country = newEmp.Country;
            emp.ProjectId = newEmp.ProjectId;

            // Step 2 Clear all managers from employee tale
            emp.Managers.Clear();
            db.SaveChanges();

            // Step 3 Update with the news, make use of managerIds of new Emp
            if (newEmp.Managers.Count != 0)
            {
                foreach (var mngr in newEmp.Managers)
                {
                    int managerID = mngr.ManagerId;
                    var manager = db.Managers.Find(managerID);
                    if (manager != null)
                    {
                        emp.Managers.Add(manager);
                    }
                }
            }

            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            
        }

        public IEnumerable<Employee> EmployeesWithProjects()
        {
            var groups = table.Include(x => x.Project).ToList();
            return groups;
        }

        public IEnumerable<Employee> EmployeesWithProjectsWithManagers()
        {
            var groups = table.Include(x => x.Project).Include(x => x.Managers).ToList();
            return groups;
        }

        public List<int> GetAllEmployeesIds(IEnumerable<Employee> employees)
        {
            List<int> employeeIds = new List<int>();
            foreach (var employee in employees)
            {
                employeeIds.Add(employee.Id);
            }
            return employeeIds;
        }

        public Employee GetAllEmployeesPerProjectPerManagerById(int? id)
        {
            var employee = table.Include(x => x.Project).Include(x => x.Managers).FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public Employee GetEmployeesWithProjectWithManagersById(int? id)
        {
            var employee = table.Include(x => x.Project).Include(x => x.Managers).FirstOrDefault(x => x.Id == id);
            return employee;
        }
    }
}
