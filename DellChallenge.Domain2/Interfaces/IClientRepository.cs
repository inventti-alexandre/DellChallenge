using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace DellChallenge.Domain.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        void Salvar(Client client);
        IEnumerable<Client> List(Client client);
    }
}
