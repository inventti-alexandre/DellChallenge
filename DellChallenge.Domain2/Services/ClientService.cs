using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EnititiesViewModel;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellChallenge.Domain.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }



        public ClientFilterViewModel List(ClientFilterViewModel filter, int idRoleUser)
        {
            var client = new Client()
            {
                City = filter.City,
                Classification = new Classification((filter.ClassificationId != null ? filter.ClassificationId.Value : 0)),
                Gender = new Gender((filter.GenderId != null ? filter.GenderId.Value : 0)),
                Id = filter.Id,
                LastPurchase = filter.LastPurchase,
                Name = filter.Name,
                Phone = filter.Phone,
                Region = new Region((filter.RegionId != null ? filter.RegionId.Value : 0)),
                Seller = new User((filter.SellerId != null ? filter.SellerId.Value : 0))
            };
            
            var clients = _repository.List(client, filter.LastPurchaseUntil).ToList();

            var clientsViewModel = clients.Select(x => new ClientResultViewModel()
            {
                City = x.City,
                Classification = x.Classification.Description,
                Gender = x.Gender.Description,
                Id = x.Id,
                LastPurchase = x.LastPurchase,
                Name = x.Name,
                Phone = x.Phone,
                RegionId = x.Region.Id
            }).ToList();

            filter.Clients = clientsViewModel;

            return filter;
        }
    }
}
