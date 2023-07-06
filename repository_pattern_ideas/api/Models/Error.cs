namespace api.Models;
public struct Error
{
    public bool IsError { get; set; }
    public string Message { get; set; }
    public string Code { get; set; }
}