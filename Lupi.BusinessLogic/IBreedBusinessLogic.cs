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

        void Add(Breed breed);
    }
}
