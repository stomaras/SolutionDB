using Entities;
using MyDatabase.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class MyDBContext: DbContext
    {
        public MyDBContext() : base("Sindesmos")
        {
            Database.SetInitializer<MyDBContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<ProjectUser> ProjectUser { get; set; }
    }
}
