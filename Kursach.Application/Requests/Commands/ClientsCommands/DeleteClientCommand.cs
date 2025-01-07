using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteClientCommand(int Id) : IRequest<bool>;
