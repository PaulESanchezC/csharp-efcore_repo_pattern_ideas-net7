namespace api.DataAccess.Repositories.EfCoreRepository;
public class EfCoreResultOption<T, TDto> : IEfCoreResultOption<T, TDto>
    where T : class
    where TDto : struct
{
    private Error _errorTemplate;
    public bool IsSuccessful { get; private set; }
    public IList<T> DatabaseObjects { get; private set; }

    public void SetErrorResult(Error errorTemplate)
    {
        _errorTemplate = errorTemplate;
        IsSuccessful = false;
        DatabaseObjects = new List<T>();
    }
    public void SetSuccessResult(List<T> responseObjects)
    {
        _errorTemplate = new();
        IsSuccessful = true;
        DatabaseObjects = responseObjects;
    }
    public void SetSuccessResult(T responseObject)
    {
        _errorTemplate = new();
        IsSuccessful = true;
        DatabaseObjects = new List<T> { responseObject };
    }
}