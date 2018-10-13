using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAppForDocker.Models;

namespace WebAppForDocker.Controllers
{
    public class HomeController : Controller
    {
        readonly IOptions<AppSettings> _appSettings;
        readonly ILogger<HomeController> _logger;

        public HomeController(IOptions<AppSettings> appSettings, ILogger<HomeController> logger ) {
            _appSettings = appSettings;
            _logger = logger;
        }

        public IActionResult Index() 
        {
            if(!System.IO.File.Exists("appsettings.json")) 
            {
                _logger.LogError("File appsettings.json must be present in project root");
                return StatusCode(500);
            }

            string environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            string appName = Environment.GetEnvironmentVariable("APP_NAME");


            ViewData["Environment"] = environment?.Length > 0 ? $"{{{environment}}}" : "{ENVIRONMENT}";
            ViewData["AppName"] = appName?.Length > 0 ? $"{{{appName}}}" : "{APP_NAME}";
            return View(_appSettings.Value);
        }
    }
}
    