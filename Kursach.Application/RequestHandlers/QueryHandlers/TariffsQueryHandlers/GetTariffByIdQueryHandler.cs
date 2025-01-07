using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetTariffByIdQueryHandler : IRequestHandler<GetTariffByIdQuery, TariffDto?>
{
	private readonly ITariffRepository _repository;
	private readonly IMapper _mapper;

	public GetTariffByIdQueryHandler(ITariffRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<TariffDto?> Handle(GetTariffByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<TariffDto>(await _repository.GetById(request.Id, trackChanges: false));
}
