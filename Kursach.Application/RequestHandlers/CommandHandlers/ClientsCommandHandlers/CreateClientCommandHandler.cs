using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
{
	private readonly IClientRepository _repository;
	private readonly IMapper _mapper;

	public CreateClientCommandHandler(IClientRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Client>(request.Client));
		await _repository.SaveChangesAsync();
	}
}
