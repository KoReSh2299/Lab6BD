using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record CreateTariffCommand(TariffForCreationDto Tariff) : IRequest;
