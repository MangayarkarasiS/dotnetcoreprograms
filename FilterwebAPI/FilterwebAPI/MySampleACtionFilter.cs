using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterwebAPI
{
    public class MySampleACtionFilter :Attribute, IActionFilter
    {
        private readonly string _name;
        public MySampleACtionFilter(string name)
        {
            _name = name;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnACtionExecuted - {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnACtionExecuting- {_name}");
        }
    }
    /* public class MySampleACtionFilter : IActionFilter
     {
         public void OnActionExecuted(ActionExecutedContext context)
         {
             Console.WriteLine("OnACtionExecuted");
         }

         public void OnActionExecuting(ActionExecutingContext context)
         {
             Console.WriteLine("OnACtionExecuting");
         }
     }*/
}
