using MediatR;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class DeleteWorkShiftPaymentCommandHandler(IWorkShiftPaymentRepository repository) : IRequestHandler<DeleteWorkShiftPaymentCommand, bool>
{
	private readonly IWorkShiftPaymentRepository _repository = repository;

	public async Task<bool> Handle(DeleteWorkShiftPaymentCommand request, CancellationToken cancellationToken)
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
