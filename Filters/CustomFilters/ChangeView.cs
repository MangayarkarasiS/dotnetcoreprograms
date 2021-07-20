using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.CustomFilters
{
    public class ChangeView : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.Result = new ViewResult
            {
                ViewName = "List"
            };
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
