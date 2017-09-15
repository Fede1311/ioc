using Lupi.Data.Entities;
using Lupi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupi.BusinessLogic
{
    public class BreedBusinessLogic : IBreedBusinessLogic
    {
        private BreedRepository repository;

        public BreedBusinessLogic()
        {
            repository = new BreedRepository();
        }

        public IEnumerable<Breed> Get()
        {
            return repository.Get();
        }

        public Breed Get(Guid id)
        {
            return repository.Get(id);
        }

        public void Add(Breed breed)
        {
            //Todo Validations
            repository.Add(breed);
        }
    }
}
