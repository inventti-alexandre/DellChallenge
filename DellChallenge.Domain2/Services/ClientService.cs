using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EnititiesViewModel;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellChallenge.Domain2.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }


        public List<ClientResultViewModel> List(ClientFilterViewModel filter)
        {
            var client = new Client()
            {
                City = filter.City,
                Classification = new Classification(filter.ClassificationId),
                Gender = new Gender(filter.GenderId),
                Id = filter.Id,
                LastPurchase = filter.LastPurchase,
                Name = filter.Name,
                Phone = filter.Phone,
                Region = filter.Region
            };

            var clients = _repository.List(client).ToList();

            var clientsViewModel = clients.Select(x => new ClientResultViewModel()
            {
                City = x.City,
                Classification = x.Classification.Description,
                Gender = x.Gender.Description,
                Id = x.Id,
                LastPurchase = x.LastPurchase,
                Name = x.Name,
                Phone = x.Phone,
                Region = x.Region
            }).ToList();

            return clientsViewModel;

        }
    }
}
