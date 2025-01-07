using MediatR;
using Kursach.Application.Dtos;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Application.Requests.Queries;

public record GetParkingSpacesPageQuery(ParkingSpaceFilter filter, int PageIndex, int PageSize) : IRequest<PaginatedList<ParkingSpaceDto>>;
