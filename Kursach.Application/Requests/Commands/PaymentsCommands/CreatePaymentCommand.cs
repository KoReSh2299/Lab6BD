using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreatePaymentCommand(PaymentForCreationDto Payment) : IRequest;
