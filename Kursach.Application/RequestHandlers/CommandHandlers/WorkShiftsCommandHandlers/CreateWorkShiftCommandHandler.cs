using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateWorkShiftCommandHandler : IRequestHandler<CreateWorkShiftCommand>
{
	private readonly IWorkShiftRepository _repository;
	private readonly IMapper _mapper;

	public CreateWorkShiftCommandHandler(IWorkShiftRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateWorkShiftCommand request, CancellationToken cancellationToken)
	{
		request.WorkShift.EmployeeIncome = request.WorkShift.Income * (decimal)0.15;

		await _repository.Create(_mapper.Map<WorkShift>(request.WorkShift));
		await _repository.SaveChangesAsync();
	}
}
