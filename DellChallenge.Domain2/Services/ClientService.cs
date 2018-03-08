using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DellChallenge.Domain.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repository;
        private IUserRepository _userRepository;
        private IGenderRepository _genderRepository;
        private IClassificationRepository _classificationRepository;
        private IRegionRepository _regionRepository;
        private ICityRepository _cityRepository;

        public ClientService(IClientRepository repository, IUserRepository userRepository, IGenderRepository genderRepository, IClassificationRepository classificationRepository, IRegionRepository regionRepository, ICityRepository cityRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _genderRepository = genderRepository;
            _classificationRepository = classificationRepository;
            _regionRepository = regionRepository;
            _cityRepository = cityRepository;
        }

        public ClientFilterViewModel List(ClientFilterViewModel clientFilter)
        {
            var client = new Client()
            {
                
                Classification = new Classification((clientFilter.ClassificationId != null ? clientFilter.ClassificationId.Value : 0)),
                Gender = new Gender((clientFilter.GenderId != null ? clientFilter.GenderId.Value : 0)),
                Id = clientFilter.Id,
                LastPurchase = clientFilter.LastPurchase,
                Name = clientFilter.Name,
                Phone = clientFilter.Phone,
                Region = new Region((clientFilter.RegionId != null ? clientFilter.RegionId.Value : 0), new City((clientFilter.CityId != null ? clientFilter.CityId.Value : 0))),
                Seller = new User((clientFilter.GetSellerId() != null ? clientFilter.GetSellerId().Value : 0))
            };
            
            var clients = _repository.List(client, clientFilter.LastPurchaseUntil).ToList();

            var clientsViewModel = clients.Select(x => new ClientResultViewModel()
            {
                City = x.Region.City.Description,
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
            clientFilter.Regions = _regionRepository.ListByCity(clientFilter.CityId).ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Sellers = _userRepository.ListSeller().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Email }).ToList();
            clientFilter.Genders = _genderRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Cities = _cityRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            
            clientFilter.SellerId = null;
            clientFilter.Clients = clientsViewModel;

            return clientFilter;
        }

        public List<Region> FilterRegions(int? cityId)
        {
            return _regionRepository.ListByCity(cityId).ToList();
        }
    }
}

