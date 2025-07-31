using FormTagHelpersCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//https://tutexchange.com/new-tag-helpers-in-asp-net-core/
//https://www.c-sharpcorner.com/blogs/validation-message-and-validation-summary-tag-helper-in-asp-net-mvc-core-31

namespace FormTagHelpersCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            // if we want value of gender from class filedo this code otherwise not needed, 
            //you can go with hardcoded value from cshtml file coding given in cshtml file pls chk
            var item = new Employee 
            { 
            gens=new List <Gendercls>
            {
                new Gendercls {Id=1,Gendnm="Male"},
                new Gendercls {Id=2,Gendnm="Female"},
                new Gendercls {Id=3,Gendnm="Others"}

            }
            };
            return View(item);
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            /*  if (ModelState.IsValid)
              {
                  ViewBag.nm = e.Email;
                  return View();
              }
              else
              {
                  ViewBag.idnm = e.Email;
                  return View("Index");
              }*/
            if (ModelState.IsValid)
            {

            }
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
