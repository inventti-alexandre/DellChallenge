using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace DellChallenge.Domain.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Client> List(Client client, DateTime? lastPurchaseUntil);
    }
}
