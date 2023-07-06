namespace api.DataAccess.Repositories;
public class Repository<T, TDto> : ResultOption<T, TDto>, IRepository<T, TDto>
    where T : class
    where TDto : struct
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<Repository<T, TDto>> _logger;
    public Repository(ApplicationDbContext db, ILogger<Repository<T, TDto>> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IResultOption<T, TDto>> CreateAsync(T objectToCreate, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Repository T:{0} | CreateAllAsync", typeof(T).Name);

        try
        {
            await _db.Set<T>().AddAsync(objectToCreate, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            SetSuccessResult(objectToCreate);
            return this;
        }
        catch (Exception e)
        {
            _logger.LogError("Repository T:{0} | CreateAllAsync | error: {@0}", typeof(T).Name, e);
            SetErrorResult(new() { Code = "1", IsError = true, Message = "empty result" });
            return this;
        }
    }

    public async Task<IResultOption<T, TDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Repository T:{0} | GetAllAsync", typeof(T).Name);
        var request = await _db.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        if (request.Count < 1)
        {
            _logger.LogError("Repository T:{0} | GetAllAsync | error: empty result", typeof(T).Name);
            SetErrorResult(new() { Code = "1", IsError = true, Message = "empty result" });
            return this;
        }

        SetSuccessResult(request);
        return this;
    }
}