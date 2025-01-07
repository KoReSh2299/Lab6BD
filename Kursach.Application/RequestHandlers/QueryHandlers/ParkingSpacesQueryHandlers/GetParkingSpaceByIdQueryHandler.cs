using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetParkingSpaceByIdQueryHandler : IRequestHandler<GetParkingSpaceByIdQuery, ParkingSpaceDto?>
{
	private readonly IParkingSpaceRepository _repository;
	private readonly IMapper _mapper;

	public GetParkingSpaceByIdQueryHandler(IParkingSpaceRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ParkingSpaceDto?> Handle(GetParkingSpaceByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<ParkingSpaceDto>(await _repository.GetById(request.Id, trackChanges: false));
}
