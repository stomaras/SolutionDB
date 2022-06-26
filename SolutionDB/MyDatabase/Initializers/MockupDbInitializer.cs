using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<MyDBContext>
    {


        protected override void Seed(MyDBContext context)
        {
            ProjectUser pu1 = new ProjectUser() { ProjectId = 1, UserId = "0c354d84-d047-4d94-b112-4b85b29b27cf", AssigmentStartDateTime = new DateTime(2021, 09, 23) };
            ProjectUser pu2 = new ProjectUser() { ProjectId = 2, UserId = "0c354d84-d047-4d94-b112-4b85b29b27cf", AssigmentStartDateTime = new DateTime(2021, 09, 23) };
            ProjectUser pu3 = new ProjectUser() { ProjectId = 3, UserId = "31991410-aade-41fc-a10e-74a41d58016d", AssigmentStartDateTime = new DateTime(2021, 09, 23) };
            ProjectUser pu4 = new ProjectUser() { ProjectId = 4, UserId = "9e6cf4fc-3be8-4ff9-8091-5795d80a7329", AssigmentStartDateTime = new DateTime(2021, 09, 23) };

            context.ProjectUser.AddOrUpdate(pu1, pu2, pu3, pu4);


            Manager m1 = new Manager() { FirstName = "George", LastName = "Pasparakis", Subject="Csharp", Salary=4000 ,PhotoUrl = "https://th.bing.com/th/id/OIP.OOh0PWJjoab-C0l3WQs4ugHaLL?w=182&h=275&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Manager m2 = new Manager() { FirstName = "Hector", LastName = "Gatsos", Subject="Java", Salary=4000 ,PhotoUrl = "https://th.bing.com/th/id/OIP.qjuMd58f14zwh0cJPKxirwHaDt?w=303&h=174&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Manager m3 = new Manager() { FirstName = "Periklis", LastName = "Aidinopoylos", Subject="Python", Salary=4000 ,PhotoUrl = "https://th.bing.com/th?id=OIF.W%2b%2bq8cue%2bxslWPm1PUj7qg&w=219&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Manager m4 = new Manager() { FirstName = "Bozas", LastName = "Panagiotis", Subject = "Javascript",Salary=4000 ,PhotoUrl = "https://th.bing.com/th?id=OIF.W%2b%2bq8cue%2bxslWPm1PUj7qg&w=219&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };

            context.Managers.AddOrUpdate(x => new { x.FirstName, x.LastName }, m1, m2, m3, m4);


            Project p1 = new Project() { ProjectName = "C#", PhotoUrl = "https://th.bing.com/th?id=OIF.xSGcXP390yUnlaLc1mvE%2fw&w=337&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p2 = new Project() { ProjectName = "Java", PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSN7kv-1JKpxoeHOk52ngjcpQjmsNEYc06wLA&usqp=CAU" };
            Project p3 = new Project() { ProjectName = "Javascript", PhotoUrl = "https://th.bing.com/th/id/OIP.dUo6EqANSW6YCSae33WmjwHaDt?w=331&h=174&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p4 = new Project() { ProjectName = "Python", PhotoUrl = "https://th.bing.com/th/id/OIP.ubux1yLT726_fVc3A7WSXgHaHa?w=177&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p5 = new Project() { ProjectName = "Sql", PhotoUrl = "https://th.bing.com/th/id/OIP.9ljgxWZSTrQnGhw-qHK8awHaEK?w=299&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p6 = new Project() { ProjectName = "Css3", PhotoUrl = "https://th.bing.com/th/id/OIP.Orlqcd9OLuiBWfyt0myqewHaHa?w=169&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p7 = new Project() { ProjectName = "Sass", PhotoUrl = "https://th.bing.com/th/id/OIP.NVhBo_44NsgCrmfaspJlJgHaEK?w=262&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p8 = new Project() { ProjectName = "Html5", PhotoUrl = "https://th.bing.com/th/id/OIP.mEqZy_F-rx8SYBrkgaZdSQHaEL?w=314&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p9 = new Project() { ProjectName = "Angular", PhotoUrl = "https://th.bing.com/th/id/OIP.kuRzuMuDyDaqAAglpORmMQHaE8?w=254&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p10 = new Project() { ProjectName = "React", PhotoUrl = "https://th.bing.com/th/id/OIP.uFOBJcuykRSmIGLYKyyGHgHaFP?w=246&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p11 = new Project() { ProjectName = "Vue", PhotoUrl = "https://th.bing.com/th/id/OIP.7cuBHJ7peZ6X-aOuCG7w5gHaFL?w=227&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p12 = new Project() { ProjectName = "Django", PhotoUrl = "https://th.bing.com/th/id/OIP.0pumuYCyFX8T6jKSvDNj2wHaEK?w=285&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p13 = new Project() { ProjectName = "Spring", PhotoUrl = "https://th.bing.com/th/id/OIP.8R5B_LRuli6JjogWugLV9QHaDt?w=316&h=174&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p14 = new Project() { ProjectName = "NodeJS", PhotoUrl = "https://th.bing.com/th/id/OIP.Uki71mYpq0z1IDbIWRsVXQHaEK?w=321&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p15 = new Project() { ProjectName = "Laravel", PhotoUrl = "https://th.bing.com/th/id/OIP.1RERMPCW2-x0N1a2nLsi-QHaC_?w=313&h=141&c=7&r=0&o=5&dpr=1.25&pid=1.7" };
            Project p16 = new Project() { ProjectName = "ASPNET", PhotoUrl = "https://th.bing.com/th/id/OIP.SdgrHy_d71WCVurB4CeUWgHaD4?w=336&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7" };

            context.Projects.AddOrUpdate(x => x.ProjectName, p1, p2, p3, p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16);

            Employee e1 = new Employee() { FirstName = "Spyros", LastName = "Tomaras", DateOfBirth = new DateTime(1997,11,01), HireDate = new DateTime(2021,11,01), Country = Country.Greece, Salary = 1200 ,PhotoUrl = "https://instagram.fath5-1.fna.fbcdn.net/v/t51.2885-19/21479902_141230403150631_8058019436604424192_a.jpg?stp=dst-jpg_s320x320&_nc_ht=instagram.fath5-1.fna.fbcdn.net&_nc_cat=107&_nc_ohc=DE8Zfk9Cmr8AX8Onpxm&edm=ABfd0MgBAAAA&ccb=7-5&oh=00_AT-nnu53MWpom_0FFUTsTrZVwGkVLHYx12xZG1XOeBBXTA&oe=62BF302B&_nc_sid=7bff83", Project = p1 };
            Employee e2 = new Employee() { FirstName = "Agathi", LastName = "Tomaras", DateOfBirth = new DateTime(1999,10,02), HireDate = new DateTime(2022,02,23), Country = Country.Germany, Salary = 1300 ,PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p2 };
            Employee e3 = new Employee() { FirstName = "Eleni", LastName = "Nikoaloy", DateOfBirth = new DateTime(1987, 05, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.France, Salary = 1300, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0" ,Project = p3 };
            Employee e4 = new Employee() { FirstName = "Vaggelis", LastName = "Kallifonis", DateOfBirth = new DateTime(1992, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Germany, Salary = 1000, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0" ,Project = p14 };
            Employee e5 = new Employee() { FirstName = "Kostas", LastName = "Tomaras", DateOfBirth = new DateTime(1998, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Greece, Salary = 900, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", };
            Employee e6 = new Employee() { FirstName = "Xristos", LastName = "Papanikolaoy", DateOfBirth = new DateTime(1990, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Italy, Salary = 1150, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p4 };
            Employee e7 = new Employee() { FirstName = "Nikiforos", LastName = "Karanikas", DateOfBirth = new DateTime(2001, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Malta, Salary = 800, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p4 };
            Employee e8 = new Employee() { FirstName = "Ntinos", LastName = "Karapiperis", DateOfBirth = new DateTime(2000, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Spain, Salary = 860, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p4 };
            Employee e9 = new Employee() { FirstName = "John", LastName = "Orgouel", DateOfBirth = new DateTime(1984, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Portugal, Salary = 986, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p12 };
            Employee e10 = new Employee() { FirstName = "Nikia", LastName = "Papanikolaoy", DateOfBirth = new DateTime(1996, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Greece, Salary = 900, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p12 };
            Employee e11 = new Employee() { FirstName = "Kostas", LastName = "Zafeiris", DateOfBirth = new DateTime(1993, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Spain, Salary = 1000, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p9 };
            Employee e12 = new Employee() { FirstName = "Kostas", LastName = "Pap", DateOfBirth = new DateTime(1997, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Germany, Salary = 1500, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p8 };
            Employee e13 = new Employee() { FirstName = "Natalia", LastName = "Zacharaki", DateOfBirth = new DateTime(1997, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Greece, Salary = 1000, PhotoUrl = "https://instagram.fath5-1.fna.fbcdn.net/v/t51.2885-19/107821293_4078916255514758_470782226564717930_n.jpg?stp=dst-jpg_s320x320&_nc_ht=instagram.fath5-1.fna.fbcdn.net&_nc_cat=102&_nc_ohc=yZcXamqEpXsAX8EhEIM&edm=ABfd0MgBAAAA&ccb=7-5&oh=00_AT_Nu7rwu9CXown9OIRg29qqPdg1J6di3TX3Uar0nUfULg&oe=62BF4072&_nc_sid=7bff83", Project = p6 };
            Employee e14 = new Employee() { FirstName = "Eirini", LastName = "Bako", DateOfBirth = new DateTime(1997, 10, 02), HireDate = new DateTime(2022, 02, 23), Country = Country.Germany, Salary = 970, PhotoUrl = "https://th.bing.com/th/id/R.39b52170999c5dc1d6c87a60cc12f60e?rik=FFJjoRY57PrkuA&pid=ImgRaw&r=0", Project = p16 };
           
            e2.Managers = new List<Manager>() { m1, m2, m3 };
            e3.Managers = new List<Manager>() { m3, m2 };
            e4.Managers = new List<Manager>() { m1, m2, m4 };
            e5.Managers = new List<Manager>() { m1, m3 };
            
            

            context.Employees.AddOrUpdate(x => new {x.FirstName, x.LastName }, e1, e2, e3, e4, e5, e6,e7,e8,e9,e10,e11,e12,e13,e14);
            base.Seed(context);
        }
    }
}
