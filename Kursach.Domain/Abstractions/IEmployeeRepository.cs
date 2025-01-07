using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IEmployeeRepository 
{
	Task<IEnumerable<Employee>> Get(bool trackChanges);
	Task<Employee?> GetById(int id, bool trackChanges);
    Task Create(Employee entity);
    void Delete(Employee entity);
    void Delete(int id);
    void Update(Employee entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Employee>> GetFilteredPageAsync(int page, int pageSize, EmployeeFilter filter, bool trackChanges);
}

