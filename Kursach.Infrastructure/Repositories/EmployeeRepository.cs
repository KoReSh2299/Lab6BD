using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Employee entity) => await _dbContext.Employees.AddAsync(entity);

    public async Task<IEnumerable<Employee>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Employees.AsNoTracking() 
            : _dbContext.Employees).ToListAsync();

    public async Task<Employee?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Employees.AsNoTracking() :
            _dbContext.Employees).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Employee entity) => _dbContext.Employees.Remove(entity);
    public void Delete(int id) => _dbContext.Employees.Remove(_dbContext.Employees.First(x => x.Id == id));

    public void Update(Employee entity) => _dbContext.Employees.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Employee>> GetFilteredPageAsync(int page, int pageSize, EmployeeFilter filter, bool trackChanges)
    {
        var query = _dbContext.Employees.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Surname))
        {
            query = query.Where(x => x.Surname.Contains(filter.Surname));
        }

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrEmpty(filter.MiddleName))
        {
            query = query.Where(x => x.MiddleName.Contains(filter.MiddleName));
        }

        return await (!trackChanges
            ? PaginatedList<Employee>.Create(query.AsNoTracking(), page, pageSize)
            : PaginatedList<Employee>.Create(query, page, pageSize));
    }
}

