using Lab2.Model;
using Lab2.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab2.Controllers
{
    [RoutePrefix("api/errors")]
    public class ErrorController : ApiController
    {
        List<Error> errors = new List<Error>
        {
            new Error(5, "Wrong format"),
            new Error(4, "Wrong params"),
            new Error(3, "There is no error"),
            new Error(2, "Student not found"),
            new Error(1, "Something went wrong")
        };
        public ErrorController() { }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetError(int id)
        {
            try
            {
                Error error = errors.Where(item => item.Code == id).First();
                var errorResponse = Request.CreateResponse(HttpStatusCode.OK, error);
                return errorResponse;
            }
            catch
            {
                Error error = errors.Where(item => item.Code == 3).First();
                var errorResponse = Request.CreateResponse(HttpStatusCode.OK, error);
                return errorResponse;
            }
        }
    }
}
