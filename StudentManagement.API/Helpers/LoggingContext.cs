using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Helpers
{
    public class LoggingContext
    {
        public LoggingContext(string serverName, string apiName, string controllerName, string actionName, int statusCode)
        {
            this.ServerName = serverName;
            this.APIName = apiName;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
            this.StatusCode = statusCode;
        }


        public string ServerName { get; set; }
        public string APIName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; }
    }
}
