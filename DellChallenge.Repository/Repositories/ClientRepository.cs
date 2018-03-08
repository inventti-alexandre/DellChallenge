using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using DellChallenge.Repository.Repositories;
using DellChallenge.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public ClientRepository()
        {
        }

        public IEnumerable<Client> List(Client client, DateTime? lastPurchaseUntil)
        {
            var clients = FakeContextSingleton.DbClient().Where(x => 
                (string.IsNullOrEmpty(client.City) || x.City.Contains(client.City) )
            && (string.IsNullOrEmpty(client.Name) || x.Name.Contains(client.Name) )
            && (string.IsNullOrEmpty(client.Phone) || x.Phone.Contains(client.Phone))
            && (client.Region.Id == 0 || x.Region.Id == client.Region.Id)
            && (client.Seller.Id == 0 || x.Seller.Id == client.Seller.Id)
            && (client.Classification.Id == 0 || x.Classification.Id == client.Classification.Id)
            && (client.Gender.Id == 0 || x.Gender.Id == client.Gender.Id)
            && (client.LastPurchase == null || x.LastPurchase.Value >= client.LastPurchase.Value)
            && (lastPurchaseUntil == null  || x.LastPurchase.Value <= lastPurchaseUntil.Value));

            return clients;
        }


        

    }
}
