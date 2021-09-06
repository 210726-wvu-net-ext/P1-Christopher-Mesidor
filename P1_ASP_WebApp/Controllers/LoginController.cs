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
    public class LoginController : Controller
    {
        private IRepo _webrepo;
        private readonly ILogger _logger;

        public LoginController(IRepo webrepo, ILogger<LoginController> logger)
        {
            _logger = logger;
            _webrepo = webrepo;
            _logger.LogCritical("This is the Login page");
        }
        // GET:  UserController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_webrepo.GetUsers().First(x => x.ID == id));
        }

        // GET:  UserController/Details/5
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        // POST:  UserController/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users users)
        {
            _webrepo.SearchUsers(users.uname,users.pass);
            return View(users);
        }

        // GET:  UserController/AddUser
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST:  UserController/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            _webrepo.AddUser(users);
            return View("Details", users);
        }
    }
}
