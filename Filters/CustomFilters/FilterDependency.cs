using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Filters.CustomFilters
{
    public interface IExceptionFilterMessage
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }

    public class ExceptionFilterMessage : IExceptionFilterMessage
    {
        private List<string> messages = new List<string>();
        public IEnumerable<string> Messages => messages;
        public void AddMessage(string message) => messages.Add(message);
    }

    public class CatchErrorMessage : IExceptionFilter
    {
        private IExceptionFilterMessage iExFilter;
        public CatchErrorMessage(IExceptionFilterMessage ex)
        {
            iExFilter = ex;
        }

        public void OnException(ExceptionContext context)
        {
            iExFilter.AddMessage("Exception Filter is called. ");
            iExFilter.AddMessage("Error Message is given below. ");
            iExFilter.AddMessage(context.Exception.Message);

            string allMessage = "";
            foreach (string message in iExFilter.Messages)
                allMessage += message;

            context.Result = new ViewResult()
            {
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = allMessage
                }
            };
        }
    }
}