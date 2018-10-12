using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAppForDocker.Models;

namespace WebAppForDocker.Controllers
{
    public class HomeController : Controller
    {
        readonly IOptions<AppSettings> _appSettings;

        public HomeController(IOptions<AppSettings> appSettings ) {
            _appSettings = appSettings;
        }

        public IActionResult Index() {
            string environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            string appName = Environment.GetEnvironmentVariable("APP_NAME");


            ViewData["Environment"] = environment?.Length > 0 ? $"{{{environment}}}" : "{ENVIRONMENT}";
            ViewData["AppName"] = appName?.Length > 0 ? $"{{{appName}}}" : "{APP_NAME}";
            return View(_appSettings.Value);
        }

    }
}
    