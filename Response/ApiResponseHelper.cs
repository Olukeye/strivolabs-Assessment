
using strivolabs_Assessment.Enums;

namespace strivolabs_Assessment.Response;


public static class ApiResponseHelper
{
    public static async Task<ApiResponse<List<T>>> SuccessList<T>(List<T> data, int totalRecord, FilterParam? pagination = null)
    {
        var resMsg = "Items fetched";
        if (data.Count == 0)
        {
            resMsg = "Empty record";
        }
        int totalpages = 0;
        int Pagenumber = 0;
        if (pagination != null && pagination.PageSize > 0 && totalRecord > 0)
        {
            totalpages = (int)Math.Round((decimal)(totalRecord / pagination.PageSize), 0, MidpointRounding.AwayFromZero) + 1;
            Pagenumber = pagination.PageNumber; //e.g 1
        }

        return new ApiResponse<List<T>>
        {
            Data = data,
            TotalRecord = totalRecord,
            Status = true,
            StatusCode = StatusEnum.Success,
            Message = resMsg,
            CurrentPage = Pagenumber,
            Pages = totalpages,
        };

    }
    public static async Task<ApiResponse<T>> SuccessListData<T>(T data, int totalRecord, FilterParam? pagination = null, string message = "Success")
    {
        int totalpages = 0;
        int Pagenumber = 0;
        if (pagination != null && pagination.PageSize > 0 && totalRecord > 0)
        {
            totalpages = (int)Math.Round((decimal)(totalRecord / pagination.PageSize), 0, MidpointRounding.AwayFromZero) + 1;
            Pagenumber = pagination.PageNumber;
        }
        return new ApiResponse<T>
        {

            Data = data,
            TotalRecord = totalRecord,
            Status = true,
            StatusCode = StatusEnum.Success,
            Message = message,
            CurrentPage = Pagenumber,
            Pages = totalpages,
        };
    }
    public static async Task<ApiResponse<T>> Success<T>(T data, string message = "Success")
    {
        return new ApiResponse<T>
        {
            Data = data,
            TotalRecord = 1,
            Message = message,
            Status = true,
            StatusCode = StatusEnum.Success
        };
    }

    public static ApiResponse ValidationError(string errorMessage)
    {
        return new ApiResponse(errorMessage, StatusEnum.Validation, false);
    }

    public static ApiResponse<T> ValidationError<T>(T data, string message)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Message = message,
            Status = false,
            StatusCode = StatusEnum.Validation
        };
    }

    public static ApiResponse Success(string message)
    {
        return new ApiResponse(message, StatusEnum.Success, true);
    }
}
