using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDto>>
{
	private readonly IClientRepository _repository;
	private readonly IMapper _mapper;

	public GetClientsQueryHandler(IClientRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<ClientDto>>(await _repository.Get(trackChanges: false));
}
