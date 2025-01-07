using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, bool>
{
	private readonly IClientRepository _repository;
	private readonly IMapper _mapper;

	public UpdateClientCommandHandler(IClientRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Client.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Client, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
