using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core.Repostories
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        List<string> GetManagersByFirstName(List<Manager> managers);
        List<string> GetManagersByLastName(List<Manager> managers);
        List<int> GetManagersById(List<Manager> managers);
    }
}
