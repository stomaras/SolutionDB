using Entities;
using Entities.Queries;
using MyDatabase;
using Repositories.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Persistance.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public List<Trainer> FilterTrainers(TrainerSearchQuery trainerSearchQuery, List<Trainer> trainers)
        {
            

            if (!string.IsNullOrEmpty(trainerSearchQuery.searchSubject))
            {
                trainers = trainers.Where(m => m.Subject.ToUpper().Contains(trainerSearchQuery.searchSubject.Trim().ToUpper())).ToList();
            }

            return trainers;


        }
    }
}
