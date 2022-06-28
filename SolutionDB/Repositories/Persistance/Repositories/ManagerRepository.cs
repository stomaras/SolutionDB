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
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {

        public ManagerRepository(MyDBContext context) : base(context)
        {

        }

        public List<string> GetManagersByFirstName(List<Manager> managers)
        {
            List<string> managersFirstName = new List<string>();
            foreach (var manager in managers)
            {
                managersFirstName.Add(manager.FirstName);
            }
            return managersFirstName;
        }

        public List<int> GetManagersById(List<Manager> managers)
        {
            List<int> managerIds = new List<int>();
            foreach (var manager in managers)
            {
                managerIds.Add(manager.ManagerId);
            }
            return managerIds;
        }

        public List<string> GetManagersByLastName(List<Manager> managers)
        {
            List<string> managersLastName = new List<string>();
            foreach (var manager in managers)
            {
                managersLastName.Add(manager.FirstName);
            }
            return managersLastName;
        }
    }
}
