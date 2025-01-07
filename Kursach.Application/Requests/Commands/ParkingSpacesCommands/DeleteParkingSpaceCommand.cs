using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteParkingSpaceCommand(int Id) : IRequest<bool>;
