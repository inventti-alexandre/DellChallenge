using DellChallange.Repository.Repositories;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Repository.Context;
using System.Collections.Generic;
using System.Linq;

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

        public List<Region> ListByCity(int? idCity)
        {
            if (idCity == null || idCity == 0)
                return new List<Region>();

            return FakeContextSingleton.DbRegion().Where(x => (x.City.Id == idCity.Value)).ToList();
        }
    }
}
