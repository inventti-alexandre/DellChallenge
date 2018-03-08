using System;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Services;
using DellChallenge.Web2.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.Web2.Controllers
{
    [Authorize, FilterSession]
    public class ClientController : BaseController
    {
        private ClientService _clientService;


        public ClientController(ClientService clientService)
        {
            _clientService = clientService;

        }

        public IActionResult Index()
        {
            var user = UserAut;

            var clientFilter = _clientService.List(new ClientFilterViewModel() { UserLoggedId = user.Id, RoleId = user.RoleId });

            return View(clientFilter);
        }

        public IActionResult FilterClients(string name, string phone, int? genderId, int? classificationId, int? sellerId, string city, string region, DateTime? lastPurchase, DateTime? lastPurchaseUntil, int? regionId)
        {
            var user = UserAut;
            var clientFilterViewModel = new ClientFilterViewModel()
            {
                Name = name,
                Phone = phone,
                GenderId = genderId,
                ClassificationId = classificationId,
                SellerId = sellerId,
                City = city,
                Region = region,
                LastPurchase = lastPurchase,
                LastPurchaseUntil = lastPurchaseUntil,
                RegionId = regionId,
                UserLoggedId = user.Id,
                RoleId = user.RoleId
            };

            var clientFilter = _clientService.List(clientFilterViewModel);

            return PartialView("_ListClients", clientFilter.Clients);
        }

        public IActionResult ClearFilter()
        {
            return View("Index");
        }
    }
}