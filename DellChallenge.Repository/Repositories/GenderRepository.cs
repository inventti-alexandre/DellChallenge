using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;

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

        public new List<Gender> List()
        {
            return DbGender();
        }

        public static List<Gender> DbGender()
        {
            var genders = new List<Gender>()
            {
                new Gender(1, "Male"),
                new Gender(2, "Female"),

            };

            return genders;
        }
    }
}
