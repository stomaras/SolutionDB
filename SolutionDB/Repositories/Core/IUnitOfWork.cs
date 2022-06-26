using Repositories.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IProjectRepository Projects { get; }
        IManagerRepository Managers { get; }

        int Complete();

    }
}
