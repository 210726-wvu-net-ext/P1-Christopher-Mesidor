using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P1_ASP_WebApp.Models;
using RR_BL;

namespace P1_ASP_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepo _webrepo;
        private readonly ILogger _logger;

        public HomeController(IRepo webrepo, ILogger<HomeController> logger)
        {
            _logger = logger;
            _webrepo = webrepo;
            _logger.LogCritical("This is the Home page");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReviews()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
