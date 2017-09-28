using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupi.BusinessLogic
{
    public interface IBreedBusinessLogic
    {
        IEnumerable<Breed> Get();

        Breed Get(Guid id);

        Guid Add(Breed breed);

        bool Update(Guid id, Breed breed);

        bool Delete(Guid id);
    }
}
