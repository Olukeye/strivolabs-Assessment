using strivolabs_Assessment.Enums;
using System.Text.Json.Serialization;

namespace strivolabs_Assessment.Response;


public class ServiceResponse
{
    public int StatusCode { get; set; }
    public List<string> Messages { get; set; } = [];
    public object? Data { get; set; } = new();
}

public class BaseResponse
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Messages { get; set; } = [];
    public object? Data { get; set; } = new();

    public BaseResponse(int statusCode, List<string> messages, object? data = null)
    {
        StatusCode = statusCode;
        Messages = messages;
        Data = data;
        IsSuccess = statusCode == StatusCodes.Status200OK;
    }
    public BaseResponse()
    {

    }
}
public class ApiResponse<TResponse>
{
    /// <summary>
    /// The status of request,if true request run completed and expected logic validations and response else there is info, warning or error message 
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Status { get; set; } = false;
    /// <summary>
    /// The statusCode to determine response message to display at client side
    /// </summary>
    public StatusEnum StatusCode { get; set; }
    /// <summary>
    /// Additional information on the reponse.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; set; }
    /// <summary>
    /// The total record for the list
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int TotalRecord { get; set; }
    /// <summary>
    /// Number of pages inline with pagesize 
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Pages { get; set; }
    /// <summary>
    /// Record current page number on view
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int CurrentPageCount { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int CurrentPage { get; set; }
    /// <summary>
    /// The contained data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public TResponse Data { get; set; }

    /// <summary>
    /// A list of error messages for errors that occured during processing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string>? Errors { get; set; }

    public bool IsEmpty() => (Errors == null || Errors.Count == 0) && Data == null && Message == null;
}

public class ApiResponse
{
    public ApiResponse(string _message, StatusEnum _statusCode, bool? _status, string? encrptData = null)
    {
        Message = _message;
        StatusCode = _statusCode;
        Status = _status;
        EncryptData = encrptData;
    }
    //public ApiResponse(string _message, StatusEnum _statusCode, bool? _status, string encrptData)
    //{
    //    Message = _message;
    //    StatusCode = _statusCode;
    //    Status = _status;
    //    EncryptData = encrptData;
    //}
    public bool? Status { get; set; } = false;
    public string Message { get; private set; }
    public string? EncryptData { get; private set; }
    public StatusEnum StatusCode { get; private set; }
}

public class IdNameRecord
{
    public string? Name { get; set; }
    public long Id { get; set; }
}
public class NameValueRecord
{
    public string? Name { get; set; }
    public string? Value { get; set; }
}

public record FilterParam
{
    //  public long MemberId { get; set; }
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public string? SearchText { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate
    {
        get; set;
    }

    public sealed class PaginatedData<T> where T : class
    {
        public PaginatedData(IEnumerable<T> records, long totalRecordsCount, int page = 1, int pageSize = 10)
        {
            Records = records;
            CurrentPage = page;
            CurrentRecordCount = records.Count();
            TotalRecordCount = totalRecordsCount;
            TotalPages = (int)Math.Round((decimal)(totalRecordsCount / pageSize), 0, MidpointRounding.AwayFromZero) + 1;
        }

        public IEnumerable<T> Records { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentRecordCount { get; set; }
        public long TotalRecordCount { get; set; }
        public int TotalPages { get; set; }
    }

}
public sealed class PaginatedData<T> where T : class
{
    public PaginatedData(IEnumerable<T> records, long totalRecordsCount, int page = 1, int pageSize = 10)
    {
        Records = records;
        CurrentPage = page;
        CurrentRecordCount = records.Count();
        TotalRecordCount = totalRecordsCount;
        TotalPages = pageSize > 0 ? (int)Math.Ceiling((decimal)totalRecordsCount / pageSize) : 0;
    }

    public IEnumerable<T> Records { get; set; }
    public int CurrentPage { get; set; }
    public int CurrentRecordCount { get; set; }
    public long TotalRecordCount { get; set; }
    public int TotalPages { get; set; }
}