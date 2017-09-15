using System;
using System.Collections.Generic;
using Lupi.Data.Entities;

namespace Lupi.Repository
{
    public interface IBreedRepository
    {
        void Add(Breed breed);
        IEnumerable<Breed> Get();
        Breed Get(Guid id);
    }
}