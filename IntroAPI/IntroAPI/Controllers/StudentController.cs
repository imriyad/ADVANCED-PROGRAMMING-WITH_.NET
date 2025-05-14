using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "Get Called");
        }
        public HttpResponseMessage Post()
        {


            return Request.CreateResponse(HttpStatusCode.OK, "Post Called");
        }
        public HttpResponseMessage Delete()
        {


            return Request.CreateResponse(HttpStatusCode.OK, "Delete Called");
        }
        public HttpResponseMessage Put()
        {


            return Request.CreateResponse(HttpStatusCode.OK, "Put Called");
        }
    }
}