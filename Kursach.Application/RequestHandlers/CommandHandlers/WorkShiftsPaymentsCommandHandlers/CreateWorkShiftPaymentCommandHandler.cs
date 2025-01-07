using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateWorkShiftPaymentCommandHandler : IRequestHandler<CreateWorkShiftPaymentCommand>
{
	private readonly IWorkShiftPaymentRepository _repository;
	private readonly IMapper _mapper;

	public CreateWorkShiftPaymentCommandHandler(IWorkShiftPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateWorkShiftPaymentCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<WorkShiftPayment>(request.WorkShiftPayment));
		await _repository.SaveChangesAsync();
	}
}
