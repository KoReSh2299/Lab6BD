using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateTariffCommandHandler : IRequestHandler<UpdateTariffCommand, bool>
{
	private readonly ITariffRepository _repository;
	private readonly IMapper _mapper;

	public UpdateTariffCommandHandler(ITariffRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateTariffCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Tariff.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Tariff, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
