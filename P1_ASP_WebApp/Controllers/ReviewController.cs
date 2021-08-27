using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace P1_ASP_WebApp.Controllers
{
    public class ReviewController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome()
        {
            
            
            return View();
        }
    }
}