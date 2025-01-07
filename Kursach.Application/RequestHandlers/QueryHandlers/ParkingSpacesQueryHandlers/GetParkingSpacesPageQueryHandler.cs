using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;
using Kursach.Domain.Utilities;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetParkingSpacesPageQueryHandler : IRequestHandler<GetParkingSpacesPageQuery, PaginatedList<ParkingSpaceDto>>
{
	private readonly IParkingSpaceRepository _repository;
	private readonly IMapper _mapper;

	public GetParkingSpacesPageQueryHandler(IParkingSpaceRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<PaginatedList<ParkingSpaceDto>> Handle(GetParkingSpacesPageQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<PaginatedList<ParkingSpaceDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.filter, false));
}
