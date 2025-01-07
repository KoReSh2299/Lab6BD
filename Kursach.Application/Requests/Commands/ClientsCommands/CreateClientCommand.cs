using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateClientCommand(ClientForCreationDto Client) : IRequest;
