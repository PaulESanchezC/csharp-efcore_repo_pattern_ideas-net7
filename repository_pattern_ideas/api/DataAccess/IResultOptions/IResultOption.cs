namespace api.DataAccess.Repositories;
public interface IResultOption<T, TDto>
    where T : class
    where TDto : struct
{
    bool IsSuccessful { get; }
    IList<T> DatabaseObjects { get; }

    void SetErrorResult(Error error);
    void SetSuccessResult(List<T> responseObjects);
    void SetSuccessResult(T responseObject);
}