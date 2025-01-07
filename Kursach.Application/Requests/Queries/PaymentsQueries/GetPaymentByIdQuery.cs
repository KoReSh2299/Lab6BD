using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetPaymentByIdQuery(int Id) : IRequest<PaymentDto?>;
