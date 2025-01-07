using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetTariffsQueryHandler : IRequestHandler<GetTariffsQuery, IEnumerable<TariffDto>>
{
	private readonly ITariffRepository _repository;
	private readonly IMapper _mapper;

	public GetTariffsQueryHandler(ITariffRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<TariffDto>> Handle(GetTariffsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<TariffDto>>(await _repository.Get(trackChanges: false));
}
