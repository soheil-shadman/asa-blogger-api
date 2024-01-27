using AsaBloggerApi.Src.Models;

namespace AsaBloggerApi.Src.Helpers
{
    public class ApiHelper
    {
        public static ApiResponse SendResponse(Object? data)
        {
            ApiResponse response = new()
            {
                Status = 200,
                Errors = "",
                Data = data
            };


            return response;
        }
        public static ApiResponse SendError(int code = 503, string error = "error")
        {
            ApiResponse response = new()
            {
                Status = code,
                Errors = error,
                Data = null
            };


            return response;
        }
          public static ApiResponse BadPatameters(string error = "bad parameters")
        {

            return SendError(502, error);
        }
        public static ApiResponse NotFound(string error = "object not found")
        {

            return SendError(404, error);
        }
         public static ApiResponse AccessDenied(string error = "access denied")
        {

            return SendError(403, error);
        }

    }
}
