using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using DellChallenge.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class ClassificationRepository : RepositoryBase<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public ClassificationRepository()
        {
        }

        public List<Classification> List()
        {
            return FakeContextSingleton.DbClassification();
        }
    }
}
