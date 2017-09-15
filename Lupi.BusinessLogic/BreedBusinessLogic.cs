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
        private IBreedRepository breedRepository;

        public BreedBusinessLogic(IBreedRepository repository)
        {
            breedRepository = repository;
        }

        public IEnumerable<Breed> Get()
        {
            return breedRepository.Get();
        }

        public Breed Get(Guid id)
        {
            return breedRepository.Get(id);
        }

        public void Add(Breed breed)
        {
            //Todo Validations
            breedRepository.Add(breed);
        }
    }
}
