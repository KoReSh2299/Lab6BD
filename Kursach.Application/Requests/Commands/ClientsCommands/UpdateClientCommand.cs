using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateClientCommand(ClientForUpdateDto Client) : IRequest<bool>;
