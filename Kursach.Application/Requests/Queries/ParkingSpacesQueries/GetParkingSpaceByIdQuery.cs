using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetParkingSpaceByIdQuery(int Id) : IRequest<ParkingSpaceDto?>;
