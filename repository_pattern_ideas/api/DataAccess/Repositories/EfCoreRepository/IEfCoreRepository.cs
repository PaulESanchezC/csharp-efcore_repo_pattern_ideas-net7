namespace api.DataAccess.Repositories.EfCoreRepository;
public interface IEfCoreRepository<T, TDto>
    where T : class
    where TDto : struct
{
    Task<IEfCoreResultOption<T, TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEfCoreResultOption<T, TDto>> CreateAsync(T objectToCreate, CancellationToken cancellationToken = default);
}