namespace api.DataAccess.Repositories;
public interface IRepository<T, TDto>
    where T : class
    where TDto : struct
{
    Task<IResultOption<T, TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IResultOption<T, TDto>> CreateAsync(T objectToCreate, CancellationToken cancellationToken = default);
}