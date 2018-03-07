using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace DellChallenge.Domain.Interfaces
{
    public interface IClassificationRepository : IRepositoryBase<Classification>
    {
        List<Classification> List();
    }
}
