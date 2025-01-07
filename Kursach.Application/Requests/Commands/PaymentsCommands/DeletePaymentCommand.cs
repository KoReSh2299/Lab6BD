using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeletePaymentCommand(int Id) : IRequest<bool>;
