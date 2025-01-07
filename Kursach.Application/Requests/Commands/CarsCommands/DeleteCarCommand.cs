using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteCarCommand(int Id) : IRequest<bool>;
