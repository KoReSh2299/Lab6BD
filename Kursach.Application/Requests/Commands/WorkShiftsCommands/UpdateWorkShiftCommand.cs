using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateWorkShiftCommand(WorkShiftForUpdateDto WorkShift) : IRequest<bool>;
