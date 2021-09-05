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

        // GET:  UserController/Details/5
        public ActionResult Login()
        {
            return View();
        }
        
        // POST:  UserController/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET:  UserController/AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        // POST:  UserController/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(string username)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
