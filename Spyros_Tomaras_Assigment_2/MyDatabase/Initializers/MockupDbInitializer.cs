using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            Trainer t1 = new Trainer() { FirstName = "George", LastName="Pasparakis", Subject = "java" };
            Trainer t2 = new Trainer() { FirstName = "Hector", LastName = "Gatsos", Subject = "c#" };
            Trainer t3 = new Trainer() { FirstName = "Periklis", LastName = "Aidinopoylos", Subject = "python" };
            Trainer t4 = new Trainer() { FirstName = "Panagiotis", LastName = "Bozas", Subject = "javascript" };

            context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName }, t1, t2, t3, t4);

            base.Seed(context);
        }
    }
}
