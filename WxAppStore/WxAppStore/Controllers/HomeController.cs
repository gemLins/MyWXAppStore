using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WxAppStore.Models;
using WxServices;

namespace WxAppStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _user;
        public HomeController(ProductService u,ILogger<HomeController> logger)
        {
            _logger = logger;
            _user = u;
        }

        public IActionResult Index( )
        {
            //UserContext u= HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
          var a= _user.GetAllProduct();
            return View(a);
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
