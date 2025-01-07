using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteDiscountCommand(int Id) : IRequest<bool>;
