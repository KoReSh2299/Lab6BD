using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IPaymentRepository 
{
	Task<IEnumerable<Payment>> Get(bool trackChanges);
	Task<Payment?> GetById(int id, bool trackChanges);
    Task Create(Payment entity);
    void Delete(Payment entity);
    void Delete(int id);
    void Update(Payment entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Payment>> GetFilteredPageAsync(int page, int pageSize, PaymentFilter filter, bool trackChanges);
}

