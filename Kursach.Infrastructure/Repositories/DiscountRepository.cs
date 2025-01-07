using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class DiscountRepository(AppDbContext dbContext) : IDiscountRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Discount entity) => await _dbContext.Discounts.AddAsync(entity);

    public async Task<IEnumerable<Discount>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Discounts.AsNoTracking() 
            : _dbContext.Discounts).ToListAsync();

    public async Task<Discount?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Discounts.AsNoTracking() :
            _dbContext.Discounts).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Discount entity) => _dbContext.Discounts.Remove(entity);

    public void Delete(int id) => _dbContext.Discounts.Remove(_dbContext.Discounts.First(x => x.Id == id));

    public void Update(Discount entity) => _dbContext.Discounts.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Discount>> GetFilteredPageAsync(int page, int pageSize, DiscountFilter filter, bool trackChanges)
    {
        var query = _dbContext.Discounts.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Description))
        {
            query = query.Where(x => x.Description.Contains(filter.Description));
        }
        var minPerc = filter.MinPercentage ?? int.MinValue;
        var maxPerc = filter.MaxPercentage ?? int.MaxValue;

        query = query.Where(x => x.Percentage >= minPerc && x.Percentage <= maxPerc);

        return await (!trackChanges
                ? PaginatedList<Discount>.Create(query.AsNoTracking(), page, pageSize)
                : PaginatedList<Discount>.Create(query, page, pageSize));
    }
}

