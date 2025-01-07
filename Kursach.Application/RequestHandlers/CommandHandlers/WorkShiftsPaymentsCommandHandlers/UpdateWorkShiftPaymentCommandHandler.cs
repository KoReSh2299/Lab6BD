using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateWorkShiftPaymentCommandHandler : IRequestHandler<UpdateWorkShiftPaymentCommand, bool>
{
	private readonly IWorkShiftPaymentRepository _repository;
	private readonly IMapper _mapper;

	public UpdateWorkShiftPaymentCommandHandler(IWorkShiftPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateWorkShiftPaymentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.WorkShiftPayment.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.WorkShiftPayment, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
