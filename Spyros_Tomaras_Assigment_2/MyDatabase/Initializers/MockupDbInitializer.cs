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
            Trainer t1 = new Trainer() { FirstName = "George", LastName="Pasparakis", Subject = "Java" };
            Trainer t2 = new Trainer() { FirstName = "Hector", LastName = "Gatsos", Subject = "Csharp" };
            Trainer t3 = new Trainer() { FirstName = "Periklis", LastName = "Aidinopoylos", Subject = "Python" };
            Trainer t4 = new Trainer() { FirstName = "Panagiotis", LastName = "Bozas", Subject = "Javascript" };

            context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName }, t1, t2, t3, t4);

            base.Seed(context);
        }
    }
}
