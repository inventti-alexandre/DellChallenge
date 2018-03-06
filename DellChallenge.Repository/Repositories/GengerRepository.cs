using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class GengerRepository : RepositoryBase<Gender>, IGengerRepository
    {
        public GengerRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }
        
    }
}
