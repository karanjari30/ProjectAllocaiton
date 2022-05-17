using ProjectAllocationAPI.Models;

namespace Core.CommanFunctions
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
