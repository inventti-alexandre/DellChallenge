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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DellChallenge.Domain.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repository;
        private IUserRepository _userRepository;
        private IGenderRepository _genderRepository;
        private IClassificationRepository _classificationRepository;
        private IRegionRepository _regionRepository;

        public ClientService(IClientRepository repository, IUserRepository userRepository, IGenderRepository gengerRepository, IClassificationRepository classificationRepository, IRegionRepository regionRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _genderRepository = gengerRepository;
            _classificationRepository = classificationRepository;
            _regionRepository = regionRepository;
        }

        public ClientFilterViewModel List(ClientFilterViewModel clientFilter)
        {
            var client = new Client()
            {
                City = clientFilter.City,
                Classification = new Classification((clientFilter.ClassificationId != null ? clientFilter.ClassificationId.Value : 0)),
                Gender = new Gender((clientFilter.GenderId != null ? clientFilter.GenderId.Value : 0)),
                Id = clientFilter.Id,
                LastPurchase = clientFilter.LastPurchase,
                Name = clientFilter.Name,
                Phone = clientFilter.Phone,
                Region = new Region((clientFilter.RegionId != null ? clientFilter.RegionId.Value : 0)),
                Seller = new User((clientFilter.GetSellerId() != null ? clientFilter.GetSellerId().Value : 0))
            };
            
            var clients = _repository.List(client, clientFilter.LastPurchaseUntil).ToList();

            var clientsViewModel = clients.Select(x => new ClientResultViewModel()
            {
                City = x.City,
                Classification = x.Classification.Description,
                Gender = x.Gender.Description,
                Id = x.Id,
                LastPurchase = x.LastPurchase,
                Name = x.Name,
                Phone = x.Phone,
                RegionId = x.Region.Id,
                Seller = x.Seller.Email,
                Region = x.Region.Description
            }).ToList();

            clientFilter.Classifications = _classificationRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Regions = _regionRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Sellers = _userRepository.ListSeller().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Email }).ToList();
            clientFilter.Genders = _genderRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();

            clientFilter.SellerId = null;
            clientFilter.Clients = clientsViewModel;

            return clientFilter;
        }
    }
}
