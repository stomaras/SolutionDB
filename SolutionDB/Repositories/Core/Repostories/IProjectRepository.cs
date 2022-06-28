using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core.Repostories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {

        List<string> GetProjectTitles(IEnumerable<Project> projects);

        List<int> GetProjectIds(IEnumerable<Project> projects);

        Project GetProjectByTitle(string projectName);
    }
}
