using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;


namespace DellChallenge.Domain.Interfaces
{
    public interface IClassificationRepository : IRepositoryBase<Classification>
    {
        void Salvar(Classification classification);
    }
}
