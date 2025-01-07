using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteWorkShiftPaymentCommand(int Id) : IRequest<bool>;
