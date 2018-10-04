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
            ViewData["Environment"] = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return View(_appSettings.Value);
        }

    }
}
