using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto?>;
