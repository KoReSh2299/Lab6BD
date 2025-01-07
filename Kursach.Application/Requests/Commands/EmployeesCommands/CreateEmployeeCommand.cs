using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateEmployeeCommand(EmployeeForCreationDto Employee) : IRequest;
