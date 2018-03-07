using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;

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
            return DbClassification();
        }


        public static  List<Classification> DbClassification()
        {
            var classification = new List<Classification>()
            {
                new Classification(1, "Gold"),
                new Classification(2, "Silver"),
                new Classification(3, "Bronze"),

            };

            return classification;
        }
    }
}
