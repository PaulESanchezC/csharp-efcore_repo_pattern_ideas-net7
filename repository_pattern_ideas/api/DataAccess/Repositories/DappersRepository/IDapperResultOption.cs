namespace api.DataAccess.Repositories.DappersRepository;
public interface IDapperResultOption<T, TDto>
    where T : struct
    where TDto : struct
{
    bool IsSuccessful { get; }
    IList<T> DatabaseObjects { get; }

    void SetErrorResult(Error error);
    void SetSuccessResult(List<T> responseObjects);
    void SetSuccessResult(T responseObject);
}