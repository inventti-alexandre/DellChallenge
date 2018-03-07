using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase <T>
    {
        void Insert(T t);
        void Update(T t);
        T Get(int id);
        //IQueryable<T> List();
        void Delete(int id);
    }
}
