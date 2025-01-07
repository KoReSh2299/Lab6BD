using Kursach.Domain.Entities;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Domain.Abstractions;

public interface ICarRepository 
{
	Task<IEnumerable<Car>> Get(bool trackChanges);
	Task<Car?> GetById(int id, bool trackChanges);
    Task Create(Car entity);
    void Delete(Car entity);
    void Delete(int id);
    void Update(Car entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Car>> GetFilteredPageAsync(int page, int pageSize, CarFilter car, bool trackChanges);
}

