using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Errors;
using System.Net;

namespace Sober.Api.Controllers.Errors
{
    //public class ErrorController : ApiController
    //{
    //    [Route("/error")]
    //    public IActionResult Error()
    //    {
    //        Exception? excepton = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //        var (statusCode, message) = excepton switch
    //        {
    //            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
    //            _ => ((int)HttpStatusCode.InternalServerError, "An unexpected error occurred.")
    //        };

    //        return Problem(statusCode: statusCode, title: message);
    //    }
    //}
}
