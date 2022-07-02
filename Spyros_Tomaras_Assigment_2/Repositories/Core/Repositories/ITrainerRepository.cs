using Entities;
using Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core.Repositories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {

        List<Trainer> FilterTrainers(TrainerSearchQuery trainerSearchQuery, List<Trainer> trainers);
    }
}
