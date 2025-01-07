using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetCarByIdQuery(int Id) : IRequest<CarDto?>;
