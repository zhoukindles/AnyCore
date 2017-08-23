using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyCore.Web.Models;
using AnyCore.Services.Test;
using AnyCore.Services.ApplicationUsers;

namespace AnyCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService testService;
        private readonly IApplicationUserService applicationUserService;


        public HomeController(ITestService testService, IApplicationUserService applicationUserService)
        {
            this.testService = testService;
            this.applicationUserService = applicationUserService;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = testService.Test();
            var list = applicationUserService.GetAll();
            ViewData["list"] = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
