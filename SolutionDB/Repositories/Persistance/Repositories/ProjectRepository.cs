using Entities;
using MyDatabase;
using Repositories.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Persistance.Repositories
{
    public class ProjectRepository : GenericRepository<Project> , IProjectRepository
    {
        public ProjectRepository(MyDBContext context) : base(context)
        {

        }
    }
}
