using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using DellChallenge.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public CityRepository()
        {
        }

        public IEnumerable<City> List()
        {
            return FakeContextSingleton.DbCicty();
        }
    }
}
