using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace DellChallenge.Domain.Interfaces
{
    public interface IRegionRepository : IRepositoryBase<Region>
    {
        List<Region> List();
    }
}
