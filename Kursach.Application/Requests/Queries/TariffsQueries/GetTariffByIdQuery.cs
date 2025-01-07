using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetTariffByIdQuery(int Id) : IRequest<TariffDto?>;
