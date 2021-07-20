using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterwebAPI.Controllers
{
    public class HomeController : Controller
    {
        [HandleException]
        public IActionResult Index()
        {
            throw new Exception("This is some exception!!!");
           // return View();
        }
    }
}
