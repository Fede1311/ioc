using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupi.Repository
{
    public class BreedRepository
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

        public void Add(Breed breed)
        {
            breed.Id = Guid.NewGuid();
            list.Add(breed);
        }
            
    }
}
