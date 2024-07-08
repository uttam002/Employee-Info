namespace Employee_Info.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1";
            response.Message = ex.Message;
            return response;
        }

        public static ApiResponse GetApiResponse(ResponseType type, object? contract)
        {
            ApiResponse response = new ApiResponse();
            response.ResponseData = contract;
            switch (type)
            {
                case ResponseType.Success:
                    response.Code = "0";
                    response.Message = "Sucess";
                    break;

                case ResponseType.NotFound:
                    response.Code = "2";
                    response.Message = "No record available";
                    break;
            }
            return response;
        }
    }
}
