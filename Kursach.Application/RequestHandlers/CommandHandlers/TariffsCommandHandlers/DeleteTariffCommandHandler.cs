using MediatR;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class DeleteTariffCommandHandler(ITariffRepository repository) : IRequestHandler<DeleteTariffCommand, bool>
{
	private readonly ITariffRepository _repository = repository;

	public async Task<bool> Handle(DeleteTariffCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Id, trackChanges: false);

        if (entity is null)
        {
            return false;
        }

        _repository.Delete(entity);
        await _repository.SaveChangesAsync();

        return true;
	}
}
