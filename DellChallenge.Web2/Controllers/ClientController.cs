using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellChallenge.Domain.EntitiesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.Web2.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
      
        public IActionResult Index()
        {
            var user = UserAut;

            var clients = new List<ClientResultViewModel>()
            {
                new ClientResultViewModel()
                {
                    Name = "1"
                },
                new ClientResultViewModel()
                {
                    Name = "2"
                },
                new ClientResultViewModel()
                {
                    Name = "3"
                }
            };

            var filterClient = new ClientFilterViewModel()
            {
                Clients = clients
            };


            return View(filterClient);
        }

        public IActionResult FilterClients()
        {
            return View();
        }

        public IActionResult ClearFilter()
        {
            return View("Index");
        }
    }
}