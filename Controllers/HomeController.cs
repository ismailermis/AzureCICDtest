using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AzureCICDtest.Models;
using Microsoft.Extensions.Configuration;

namespace AzureCICDtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _iConfig;
        public HomeController(ILogger<HomeController> logger,IConfiguration iConfig)
        {
            _logger = logger;
            _iConfig=iConfig;
        }

        public IActionResult Index()
        {
            string value =  _iConfig.GetValue<string>("MySettings:Name");
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
