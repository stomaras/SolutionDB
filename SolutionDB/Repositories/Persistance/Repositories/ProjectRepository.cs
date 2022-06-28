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

        public Project GetProjectByTitle(string projectName)
        {
            var projects = GetAll();
            foreach (var pro in projects)
            {
                if(pro.ProjectName == projectName)
                {
                    return pro;
                }
            }
            return null;
        }

        public List<int> GetProjectIds(IEnumerable<Project> projects)
        {
            List<int> projectIds = (from pro in projects
                                    select pro.ProjectId).ToList();

            return projectIds;
        }

        public List<string> GetProjectTitles(IEnumerable<Project> projects)
        {
            List<string> projectTitles = (from pro in projects
                                          select pro.ProjectName).ToList();
            return projectTitles;
        }
    }
}
