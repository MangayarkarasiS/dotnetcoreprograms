using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        //[RequireHttps]
        //[HttpsOnly]
        [TimeElapsed]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        //[ChangeView]
        [ChangeViewAsync]
        public ViewResult Message() => View();

        [HybridActRes]
        public IActionResult List() => View();

        [CatchError]
        //[TypeFilter(typeof(CatchErrorMessage))]
        public IActionResult Exception(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Error Id cannot be null");
                else
                    return View((object)$"The value is {id}");
            }
            catch(Exception e)
            {
                return View( );
            }
        }
    }
}