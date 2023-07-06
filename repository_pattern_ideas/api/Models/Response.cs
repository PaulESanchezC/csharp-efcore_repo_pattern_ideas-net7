namespace api.Models;
public struct Response<T>
    where T : struct
{
    public bool IsSuccessfull { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public int ResponseCount { get; set; }
    public int TotalCount { get; set; }
    public List<T> ResponseObject { get; set; }

    public static Response<T> OK200() => new Response<T>()
    {
        IsSuccessfull = true,
        Message = "ok",
        StatusCode = 200
    };

    public static Response<T> BadRequest400(string message = "bad request") => new Response<T>()
    {
        IsSuccessfull = false,
        Message = message,
        StatusCode = 400
    };
}