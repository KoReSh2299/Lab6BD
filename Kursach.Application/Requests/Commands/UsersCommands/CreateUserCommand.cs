using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateUserCommand(UserForCreationDto User) : IRequest;
