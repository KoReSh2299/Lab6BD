using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetTariffsQuery : IRequest<IEnumerable<TariffDto>>;
