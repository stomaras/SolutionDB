using MyDatabase;
using Repositories.Core;
using Repositories.Core.Repostories;
using Repositories.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyDBContext context;

        public UnitOfWork(MyDBContext dbContext)
        {
            context = dbContext;
            Employees = new EmployeeRepository(context);
            Projects = new ProjectRepository(context);
            Managers = new ManagerRepository(context);

        }
        public IEmployeeRepository Employees { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public IManagerRepository Managers { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
