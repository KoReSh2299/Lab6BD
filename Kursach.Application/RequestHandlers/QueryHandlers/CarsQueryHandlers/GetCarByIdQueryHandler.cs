using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto?>
{
	private readonly ICarRepository _repository;
	private readonly IMapper _mapper;

	public GetCarByIdQueryHandler(ICarRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<CarDto>(await _repository.GetById(request.Id, trackChanges: false));
}
