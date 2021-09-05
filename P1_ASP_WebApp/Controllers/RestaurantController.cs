using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P1_ASP_WebApp.Models;
using RR_BL;

namespace P1_ASP_WebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private IRepo _webrepo;
        private readonly ILogger _logger;

        public RestaurantController(IRepo webrepo, ILogger<RestaurantController> logger)
        {
            _logger = logger;
            _webrepo = webrepo;
            _logger.LogCritical("This is the Restaurants page");
        }
        // GET: HomeController1
        public IActionResult Index()
        {

            return View(_webrepo.GetRestaurants());
        }

       
    }
}
