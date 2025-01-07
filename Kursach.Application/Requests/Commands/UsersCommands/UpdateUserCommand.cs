using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateUserCommand(UserForUpdateDto User) : IRequest<bool>;
