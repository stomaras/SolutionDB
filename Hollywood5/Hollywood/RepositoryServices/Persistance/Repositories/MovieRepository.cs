using Entities;
using MyDatabase;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        
        public MovieRepository(ApplicationDbContext context) :base(context)
        {

        }

        public IEnumerable<Movie> GetMoviesOrderByAscending()
        {
            return table.OrderBy(x=>x.Title).ToList();
        }
    }
}
