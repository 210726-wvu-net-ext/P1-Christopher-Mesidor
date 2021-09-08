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
    public class ReviewsController : Controller
    {
        private IRepo _webrepo;
        private readonly ILogger _logger;

        public ReviewsController(IRepo webrepo, ILogger<ReviewsController> logger)
        {
            _logger = logger;
            _webrepo = webrepo;
        }

        public IActionResult Index()
        {
            return View(_webrepo.GetReviews());
        }
        public IActionResult Details(int id)
        {
            return View(_webrepo.GetReviews().First(x => x.ID == id));
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]          // For submission (by default)
        public IActionResult Create(Reviews reviews)
        {
            _webrepo.AddReviews(reviews);
            _logger.LogCritical("New Review added");
            return View("Details", reviews);
        }
    }
}