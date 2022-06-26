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
    public class MockupDbInitializer : CreateDatabaseIfNotExists<MyDBContext>
    {


        protected override void Seed(MyDBContext context)
        {

            Manager m1 = new Manager() { FirstName = "George", LastName = "Pasparakis" };
            Manager m2 = new Manager() { FirstName = "Hector", LastName = "Gatsos" };
            Manager m3 = new Manager() { FirstName = "Periklis", LastName = "Aidinopoylos" };
            Manager m4 = new Manager() { FirstName = "Bozas", LastName = "Panagiotis" };

            context.Managers.AddOrUpdate(x => new { x.FirstName, x.LastName }, m1, m2, m3, m4);


            Project p1 = new Project() { ProjectName = "C#" };
            Project p2 = new Project() { ProjectName = "Java" };
            Project p3 = new Project() { ProjectName = "Javascript" };
            Project p4 = new Project() { ProjectName = "Python" };
            Project p5 = new Project() { ProjectName = "Sql" };
            Project p6 = new Project() { ProjectName = "Css3" };
            Project p7 = new Project() { ProjectName = "Sass" };
            Project p8 = new Project() { ProjectName = "Html5" };
            Project p9 = new Project() { ProjectName = "Angular" };
            Project p10 = new Project() { ProjectName = "React" };
            Project p11 = new Project() { ProjectName = "Vue" };
            Project p12 = new Project() { ProjectName = "Django" };
            Project p13 = new Project() { ProjectName = "Spring" };
            Project p14 = new Project() { ProjectName = "NodeJS" };
            Project p15 = new Project() { ProjectName = "Laravel" };
            Project p16 = new Project() { ProjectName = "ASPNET" };

            context.Projects.AddOrUpdate(x => x.ProjectName, p1, p2, p3, p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16);

            Employee e1 = new Employee() { FirstName = "Spyros", LastName = "Tomaras", Project = p1 };
            Employee e2 = new Employee() { FirstName = "Agathi", LastName = "Tomaras", Project = p2 };
            Employee e3 = new Employee() { FirstName = "Eleni", LastName = "Nikoaloy", Project = p3 };
            Employee e4 = new Employee() { FirstName = "Vaggelis", LastName = "Kallifonis", Project = p14 };
            Employee e5 = new Employee() { FirstName = "Kostas", LastName = "Tomaras" };
            Employee e6 = new Employee() { FirstName = "Xristos", LastName = "Papanikolaoy", Project = p4 };
            Employee e7 = new Employee() { FirstName = "Nikiforos", LastName = "Karanikas", Project = p4 };
            Employee e8 = new Employee() { FirstName = "Ntinos", LastName = "Karapiperis", Project = p4 };
            Employee e9 = new Employee() { FirstName = "John", LastName = "Orgouel", Project = p12 };
            Employee e10 = new Employee() { FirstName = "Nikia", LastName = "Papanikolaoy", Project = p12 };
            Employee e11 = new Employee() { FirstName = "Kostas", LastName = "Zafeiris", Project = p9 };
            Employee e12 = new Employee() { FirstName = "Kostas", LastName = "Pap", Project = p8 };
            Employee e13 = new Employee() { FirstName = "Natalia", LastName = "Zacharaki", Project = p6 };
            Employee e14 = new Employee() { FirstName = "Eirini", LastName = "Bako", Project = p16 };
           
            e2.Managers = new List<Manager>() { m1, m2, m3 };
            e3.Managers = new List<Manager>() { m3, m2 };
            e4.Managers = new List<Manager>() { m1, m2, m4 };
            e5.Managers = new List<Manager>() { m1, m3 };
            
            

            context.Employees.AddOrUpdate(x => new {x.FirstName, x.LastName }, e1, e2, e3, e4, e5, e6,e7,e8,e9,e10,e11,e12,e13,e14);
            base.Seed(context);
        }
    }
}
