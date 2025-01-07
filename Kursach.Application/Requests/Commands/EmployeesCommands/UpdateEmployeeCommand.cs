using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateEmployeeCommand(EmployeeForUpdateDto Employee) : IRequest<bool>;
