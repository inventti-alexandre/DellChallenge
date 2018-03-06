using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase <T>
    {
        void Inserir(T t);
        void Atualizar(T t);
        T RecuperarPorId(int id);
        IQueryable<T> List();
        void Excluir(int id);
    }
}
