using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateParkingSpaceCommand(ParkingSpaceForCreationDto ParkingSpace) : IRequest;
