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
        }
        // GET: HomeController1
        public IActionResult Index()
        {
            return View(_webrepo.GetRestaurants());
        }

        public IActionResult Details(int id)
        {
            _logger.LogCritical("Showing the restaurant");
            return View(_webrepo.GetRestaurants().First(x => x.ID == id));
        }

        [HttpGet]
        public ActionResult SearchRestaurant()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchRestaurant(Restaurants restaurants)
        {

            if(_webrepo.SearchRestaurants(restaurants.Name).Equals("Restaurant does not exist"))
            {
                return View("Error");
            }
            else
            {
                ViewBag.Username = restaurants.Name;
                TempData["restaurant"] = restaurants.Name;
                TempData.Keep("restaurant");
                _logger.LogCritical("Found Restaurant");
                return View("Details", restaurants);
            }
        }
    }
}
