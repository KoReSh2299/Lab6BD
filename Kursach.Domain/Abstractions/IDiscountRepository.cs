using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IDiscountRepository 
{
	Task<IEnumerable<Discount>> Get(bool trackChanges);
	Task<Discount?> GetById(int id, bool trackChanges);
    Task Create(Discount entity);
    void Delete(Discount entity);
    void Delete(int id);
    void Update(Discount entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Discount>> GetFilteredPageAsync(int page, int pageSize, DiscountFilter filter, bool trackChanges);
}

