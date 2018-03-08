using System;
using System.Linq;
using System.Net;
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

        public IActionResult FilterClients(string name, string phone, int? genderId, int? classificationId, int? sellerId, int? cityId, string region, string lastPurchase, string lastPurchaseUntil, int? regionId)
        {
            try
            {
                var user = UserAut;
                var clientFilterViewModel = new ClientFilterViewModel(name, phone, genderId, classificationId, sellerId, cityId, region, regionId, user.Id, user.RoleId, lastPurchase, lastPurchaseUntil);

                var clientFilter = _clientService.List(clientFilterViewModel);

                return PartialView("_ListClients", clientFilter.Clients);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadGateway;
                return Json(new {   errors = ex.Message });
            }
        }

        public IActionResult FilterRegions(int cityId)
        {
            var clientFilter = _clientService.FilterRegions(cityId);
            var listToReturn = clientFilter.Select(c =>
                             new
                             {
                                 Value = c.Id,
                                 Text = c.Description
                             }).ToList();

            return Json(new { success = true, obj = listToReturn });
        }

        public IActionResult ClearFilter()
        {
            return View("Index");
        }
    }
}