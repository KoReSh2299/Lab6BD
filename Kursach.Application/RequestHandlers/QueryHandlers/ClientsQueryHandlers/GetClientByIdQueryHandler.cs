using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto?>
{
	private readonly IClientRepository _repository;
	private readonly IMapper _mapper;

	public GetClientByIdQueryHandler(IClientRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ClientDto?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<ClientDto>(await _repository.GetById(request.Id, trackChanges: false));
}
