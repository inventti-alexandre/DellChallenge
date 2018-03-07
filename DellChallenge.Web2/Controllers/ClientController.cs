using System;
using System.Linq;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DellChallenge.Web2.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        private ClientService _clientService;
        private IUserRepository _userRepository;
        private IGenderRepository _genderRepository;
        private IClassificationRepository _classificationRepository;
        private IRegionRepository _regionRepository;

        public ClientController(ClientService clientService, IUserRepository userRepository, IGenderRepository gengerRepository, IClassificationRepository classificationRepository, IRegionRepository regionRepository)
        {
            _clientService = clientService;
            _userRepository = userRepository;
            _genderRepository = gengerRepository;
            _classificationRepository = classificationRepository;
            _regionRepository = regionRepository;
        }

        public IActionResult Index()
        {
            var user = UserAut;

            var clientFilter = _clientService.List(new ClientFilterViewModel() { SellerId = user.Id, Role = user.RoleId }, user.RoleId);

            clientFilter.Classifications = _classificationRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Regions = _regionRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();
            clientFilter.Sellers = _userRepository.ListSeller().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Email }).ToList();
            clientFilter.Genders = _genderRepository.List().ToList().Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Description }).ToList();

            return View(clientFilter);
        }

        public IActionResult FilterClients(string Name,string Phone ,int? GenderId,int? ClassificationId, int? SellerId, string City , string Region , DateTime? LastPurchase , DateTime? LastPurchaseUntil, int? RegionId)
        {
            var user = UserAut;
            var clientFilterViewModel = new ClientFilterViewModel()
            {
                Name = Name,
                Phone = Phone,
                GenderId = GenderId,
                ClassificationId = ClassificationId,
                SellerId = user.Id,
                City = City,
                Region = Region,
                LastPurchase = LastPurchase,
                LastPurchaseUntil = LastPurchaseUntil,
                RegionId = RegionId,
            };

            var clientFilter = _clientService.List(clientFilterViewModel, user.RoleId);

            return PartialView("_ListClients", clientFilter.Clients);
        }

        public IActionResult ClearFilter()
        {
            return View("Index");
        }
    }
}