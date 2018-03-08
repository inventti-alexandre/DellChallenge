using System;
using System.Net;
using DellChallenge.Domain.EntitiesViewModel;
using DellChallenge.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.Web2.Controllers
{
    [Authorize]
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

        public IActionResult FilterClients(string name, string phone, int? genderId, int? classificationId, int? sellerId, string city, string region, string lastPurchase, string lastPurchaseUntil, int? regionId)
        {
            try
            {
                var user = UserAut;
                var clientFilterViewModel = new ClientFilterViewModel(name, phone, genderId, classificationId, sellerId, city, region, regionId, user.Id, user.RoleId, lastPurchase, lastPurchaseUntil);

                var clientFilter = _clientService.List(clientFilterViewModel);

                return PartialView("_ListClients", clientFilter.Clients);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadGateway;
                return Json(new {   errors = ex.Message });
            }
        }

        public IActionResult ClearFilter()
        {
            return View("Index");
        }
    }
}