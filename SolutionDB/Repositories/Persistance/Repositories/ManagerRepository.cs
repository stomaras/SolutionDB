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
    }
}
