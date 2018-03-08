using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using DellChallenge.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public GenderRepository()
        {
        }

        public List<Gender> List()
        {
            return FakeContextSingleton.DbGender();
        }
    }
}
