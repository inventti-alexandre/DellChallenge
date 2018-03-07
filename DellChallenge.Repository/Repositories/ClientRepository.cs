using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using DellChallenge.Repository.Repositories;

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
            var clients = DbClient().Where(x => 
                (string.IsNullOrEmpty(client.City) || x.City.Contains(client.City) )
            && (string.IsNullOrEmpty(client.Name) || x.Name.Contains(client.Name) )
            && (string.IsNullOrEmpty(client.Phone) || x.Phone.Contains(client.Phone))
            && (client.Region.Id == 0 || x.Region.Id == client.Region.Id)
            && (client.Seller.Id == 0 || x.Seller.Id == client.Seller.Id)
            && (client.Classification.Id == 0 || x.Classification.Id == client.Classification.Id)
            && (client.Gender.Id == 0 || x.Gender.Id == client.Gender.Id)
            && (client.LastPurchase == null || x.LastPurchase.Value >= client.LastPurchase.Value)
            && (lastPurchaseUntil == null  || x.LastPurchase <= lastPurchaseUntil));

            return clients;
        }


        public static List<Client> DbClient()
        {
            var users = UserRepository.DbUser();
            var genders = GenderRepository.DbGender();
            var classifications = ClassificationRepository.DbClassification();
            var regions = RegionRepository.DbRegion();

            var clients = new List<Client>()
            {
                new Client(1, "Kelly", "55995599", genders[1], classifications[0], "NY", regions[0], DateTime.Now.AddDays(-2), users[1]),
                new Client(1, "Brian", "55886677", genders[0], classifications[1], "NY", regions[1], DateTime.Now.AddDays(-1), users[1]),
                new Client(1, "Brown", "44556677", genders[0], classifications[2], "NY", regions[1], DateTime.Now.AddDays(0), users[1]),
                new Client(1, "Katy", "88113344", genders[1], classifications[1], "NY", regions[2], DateTime.Now.AddDays(2), users[2]),
                new Client(1, "Kelly", "99557777", genders[1], classifications[0], "NY", regions[3], DateTime.Now.AddDays(3), users[2])

            };

            return clients;
        }

    }
}
