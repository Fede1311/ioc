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

        public Guid Add(Breed breed)
        {
            //Todo Validations
            return breedRepository.Add(breed);
        }

        public bool Update(Guid id, Breed breed)
        {
            return breedRepository.Update(id, breed);
        }

        public bool Delete(Guid id)
        {
            return breedRepository.Delete(id);
        }
    }
}
