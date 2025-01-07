using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteTariffCommand(int Id) : IRequest<bool>;
