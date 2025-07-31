using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace KeepNote.Aspect
{
    /*Override the methods of ActionFilterAttribute to log the information into file
     * at given file path.
    */
    public class LoggingAspect : ActionFilterAttribute
    {
        string logFilePath;
       
        public LoggingAspect(IHostingEnvironment environment)
        {
            logFilePath = environment.ContentRootPath + @"/LogFile.txt";
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(logFilePath, "OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(logFilePath, "OnActionExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(logFilePath, "OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(logFilePath, "OnResultExecuting", filterContext.RouteData);
        }

        private void Log(string path, string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];

            FileStream fs = null;
            if (!File.Exists(logFilePath))
            {
                fs = new FileStream(logFilePath, FileMode.Create, FileAccess.Write);
            }
            else if (File.ReadAllText(logFilePath) == "")
            {
                fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Write);
            }
            else if (File.ReadAllText(logFilePath) != "")
            {
                fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write);
            }
            StreamWriter w = new StreamWriter(fs);
            string str = methodName + ", controller: " + controllerName + ", action method: " + actionName + ", date:" + DateTime.Now;
            w.WriteLine(str);
            w.Flush();
            w.Close();
            fs.Close();
            //Debug.WriteLine("OnActionExecuted, controller: " + controllerName + ", action method: " + actionName + ", date:" + DateTime.Now);
        }

    }
}
