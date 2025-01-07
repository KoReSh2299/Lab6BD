using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdatePaymentCommand(PaymentForUpdateDto Payment) : IRequest<bool>;
