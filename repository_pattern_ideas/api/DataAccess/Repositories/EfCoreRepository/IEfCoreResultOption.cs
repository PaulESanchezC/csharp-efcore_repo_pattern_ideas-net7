namespace api.DataAccess.Repositories.EfCoreRepository;
public interface IEfCoreResultOption<T, TDto>
    where T : class
    where TDto : struct
{
    bool IsSuccessful { get; }
    IList<T> DatabaseObjects { get; }

    void SetErrorResult(Error error);
    void SetSuccessResult(List<T> responseObjects);
    void SetSuccessResult(T responseObject);
}