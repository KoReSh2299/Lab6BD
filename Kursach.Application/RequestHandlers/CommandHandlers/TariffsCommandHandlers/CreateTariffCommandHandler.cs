using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateTariffCommandHandler : IRequestHandler<CreateTariffCommand>
{
	private readonly ITariffRepository _repository;
	private readonly IMapper _mapper;

	public CreateTariffCommandHandler(ITariffRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateTariffCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Tariff>(request.Tariff));
		await _repository.SaveChangesAsync();
	}
}
