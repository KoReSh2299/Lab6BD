using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;
using Kursach.Domain.Utilities;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<CarDto>>
{
	private readonly ICarRepository _repository;
	private readonly IMapper _mapper;

	public GetCarsQueryHandler(ICarRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<CarDto>>(await _repository.Get(false));
}
