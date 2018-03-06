using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.Web2.Controllers
{
    
    public class ClientController : BaseController
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}