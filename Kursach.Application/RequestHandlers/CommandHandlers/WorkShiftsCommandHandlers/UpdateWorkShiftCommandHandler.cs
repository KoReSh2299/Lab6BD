using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateWorkShiftCommandHandler(IWorkShiftRepository repository, IMapper mapper) : IRequestHandler<UpdateWorkShiftCommand, bool>
{
	private readonly IWorkShiftRepository _repository = repository;
	private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdateWorkShiftCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.WorkShift.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		request.WorkShift.EmployeeIncome = request.WorkShift.Income * (decimal)0.15;

		_mapper.Map(request.WorkShift, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
