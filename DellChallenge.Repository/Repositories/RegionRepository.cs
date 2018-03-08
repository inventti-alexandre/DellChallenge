using DellChallange.Repository.Repositories;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Repository.Context;
using System.Collections.Generic;

namespace DellChallenge.Repository.Repositories
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository()
        {
        }

        public List<Region> List()
        {
            return FakeContextSingleton.DbRegion();
        }
    }
}
