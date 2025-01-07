using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateParkingSpaceCommand(ParkingSpaceForUpdateDto ParkingSpace) : IRequest<bool>;
