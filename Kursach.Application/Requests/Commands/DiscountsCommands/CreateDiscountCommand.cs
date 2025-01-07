using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateDiscountCommand(DiscountForCreationDto Discount) : IRequest;
