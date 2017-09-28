using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupi.Repository
{
    public class BreedRepository : IBreedRepository
    {
        private static List<Breed> list = new List<Breed>();

        public BreedRepository()
        {
        }

        public IEnumerable<Breed> Get()
        {
            return list;
        }

        public Breed Get(Guid id)
        {
            return list.Find(x => x.Id.Equals(id));
        }

        public Guid Add(Breed breed)
        {
            breed.Id = Guid.NewGuid();
            list.Add(breed);
            return breed.Id;
        }

        public bool Update(Guid id, Breed breed)
        {
            Breed oldBreed = Get(id);
            if(oldBreed == null)
            {
                return false;
            }
            oldBreed.Name = breed.Name;
            oldBreed.HairType = breed.HairType;
            oldBreed.HairColors = breed.HairColors;
            return true;
        }

        public bool Delete(Guid id)
        {
            Breed oldBreed = Get(id);
            if (oldBreed == null)
            {
                return false;
            }
            return list.Remove(oldBreed);
        }
    }
}
