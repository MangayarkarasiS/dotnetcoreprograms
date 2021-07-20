using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ShowMessage("Controller")]
    //[ShowMessage("Controller", Order = 2)]
    public class OrderController : Controller
    {
        [ShowMessage("Action")]
        //[ShowMessage("Action", Order = -1)]
        public IActionResult Index()
        {
            return View();
        }
    }
}