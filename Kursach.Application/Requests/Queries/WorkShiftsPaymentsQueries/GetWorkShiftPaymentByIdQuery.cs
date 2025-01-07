using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetWorkShiftPaymentByIdQuery(int Id) : IRequest<WorkShiftPaymentDto?>;
