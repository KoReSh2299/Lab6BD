using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteUserCommand(int Id) : IRequest<bool>;
