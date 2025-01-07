using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteWorkShiftCommand(int Id) : IRequest<bool>;
