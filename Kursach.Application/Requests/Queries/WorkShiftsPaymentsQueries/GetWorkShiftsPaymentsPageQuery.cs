using Kursach.Application.Dtos;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;
using MediatR;

namespace Kursach.Application.Requests.Queries;

public record GetWorkShiftsPaymentsPageQuery(WorkShiftPaymentFilter Filter, int PageIndex, int PageSize) : IRequest<PaginatedList<WorkShiftPaymentDto>>;