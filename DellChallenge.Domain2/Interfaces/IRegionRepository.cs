using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.Domain.Interfaces
{
    public interface IRegionRepository : IRepositoryBase<Region>
    {
        List<Region> List();
    }
}
