using MediatR;

namespace Kursach.Application.Requests.Commands;

public record DeleteEmployeeCommand(int Id) : IRequest<bool>;
