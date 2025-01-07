using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class TariffRepository(AppDbContext dbContext) : ITariffRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Tariff entity) => await _dbContext.Tariffs.AddAsync(entity);

    public async Task<IEnumerable<Tariff>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Tariffs.AsNoTracking() 
            : _dbContext.Tariffs).ToListAsync();

    public async Task<Tariff?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Tariffs.AsNoTracking() :
            _dbContext.Tariffs).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Tariff entity) => _dbContext.Tariffs.Remove(entity);

    public void Delete(int id) => _dbContext.Tariffs.Remove(_dbContext.Tariffs.First(x => x.Id == id));

    public void Update(Tariff entity) => _dbContext.Tariffs.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Tariff>> GetFilteredPageAsync(int page, int pageSize, TariffFilter filter, bool trackChanges)
    {
        var query = _dbContext.Tariffs.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Description))
        {
            query = query.Where(x => x.Description.Contains(filter.Description));
        }

        var minRate = filter.MinRate ?? 0m;
        var maxRate = filter.MaxRate ?? 99999999.99m;

        query = query.Where(x => x.Rate >= minRate && x.Rate <= maxRate);

        return await (!trackChanges
            ? PaginatedList<Tariff>.Create(query.AsNoTracking(), page, pageSize)
            : PaginatedList<Tariff>.Create(query, page, pageSize));
    }
}

