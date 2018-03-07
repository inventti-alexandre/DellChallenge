using DellChallange.Repository.Repositories;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using System.Collections.Generic;

namespace DellChallenge.Repository.Repositories
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository()
        {
        }

        public new List<Region> List()
        {
            return DbRegion();
        }

        public static List<Region> DbRegion()
        {
            var retions = new List<Region>()
            {
                new Region(1, "North"),
                new Region(2, "South"),
                new Region(3, "Weast"),
                new Region(4, "East"),
            };

            return retions;
        }
    }
}
