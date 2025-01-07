using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateWorkShiftPaymentCommand(WorkShiftPaymentForUpdateDto WorkShiftPayment) : IRequest<bool>;
