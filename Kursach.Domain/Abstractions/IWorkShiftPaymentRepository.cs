using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IWorkShiftPaymentRepository 
{
	Task<IEnumerable<WorkShiftPayment>> Get(bool trackChanges);
	Task<WorkShiftPayment?> GetById(int id, bool trackChanges);
    Task Create(WorkShiftPayment entity);
    void Delete(WorkShiftPayment entity);
    void Delete(int id);
    void Update(WorkShiftPayment entity);
    Task SaveChangesAsync();
    Task<PaginatedList<WorkShiftPayment>> GetFilteredPageAsync(int page, int pageSize, WorkShiftPaymentFilter filter, bool trackChanges);
}

