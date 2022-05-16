using ProjectAllocationAPI.Helper;
using ProjectAllocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectAllocationAPI.Controllers
{
    public class LogInController : ApiController
    {
        public JsonResponse LogIn(LogIn model)
        {
            var objectResponse = new JsonResponse();
            
            return objectResponse;
        }
    }
}
