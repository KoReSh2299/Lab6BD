using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IWorkShiftRepository 
{
	Task<IEnumerable<WorkShift>> Get(bool trackChanges);
	Task<WorkShift?> GetById(int id, bool trackChanges);
    Task Create(WorkShift entity);
    void Delete(WorkShift entity);
    void Delete(int id);
    void Update(WorkShift entity);
    Task SaveChangesAsync();
    Task<PaginatedList<WorkShift>> GetFilteredPageAsync(int page, int pageSize, WorkShiftFilter filter, bool trackChanges);
    Task<PaginatedList<EmployeeWorkSummary>> GetFilteredPageAsync(int page, int pageSize, EmployeeWorkSummaryFilter filter, bool trackChanges);
}

