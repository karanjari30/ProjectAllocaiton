using ProjectAllocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAllocationAPI.Helper
{
    public class JsonResponseHelper
    {
        public static JsonResponse JsonMessage(int ResponseStatus, string Message, dynamic Result)
        {
            var objectResponse = new JsonResponse
            {
                ResponseStatus = ResponseStatus,
                Message = Message,
                Result = Result
            };
            return objectResponse;
        }
    }
}