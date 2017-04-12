using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigisensePlatformAPIs.Controllers
{
    public class ErrorController : ApiController
    {
        //[HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        //public HttpResponseMessage Handle404()
        //{
        //    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
        //    responseMessage.ReasonPhrase = "The requested resource is not found";
        //    return responseMessage;
        //}

        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public HttpResponseMessage Handle404()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("The requested resource is not found"));
        }
    }
}
