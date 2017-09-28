using System;
using System.Collections.Generic;
using Lupi.Data.Entities;

namespace Lupi.Repository
{
    public interface IBreedRepository
    {
        IEnumerable<Breed> Get();
        Breed Get(Guid id);
        Guid Add(Breed breed);
        bool Update(Guid id, Breed breed);
        bool Delete(Guid id);
    }
}