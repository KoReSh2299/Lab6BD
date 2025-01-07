using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateDiscountCommand(DiscountForUpdateDto Discount) : IRequest<bool>;
