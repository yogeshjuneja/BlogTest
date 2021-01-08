using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTImplementation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public MyErrorResponse Index()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;  
            Response.StatusCode = 500; 

            return  new MyErrorResponse(exception);
        }
    }

    public class MyErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public MyErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
        }
    }
}
