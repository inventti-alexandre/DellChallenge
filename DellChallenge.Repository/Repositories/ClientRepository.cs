using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace DellChallange.Repository.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public IEnumerable<Client> List(Client client)
        {
            var clients = DbSet.Where(x => x.Gender.Id == client.Gender.Id);
            return clients;

        }

        public void Salvar(Client client)
        {
            if (client.Id == 0)
            {
                Inserir(client);
            }
            else
            {
                Atualizar(client);
            }
        }
    }
}
