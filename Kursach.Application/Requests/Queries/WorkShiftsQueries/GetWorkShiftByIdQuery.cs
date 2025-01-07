using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetWorkShiftByIdQuery(int Id) : IRequest<WorkShiftDto?>;
