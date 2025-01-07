using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetWorkShiftsPaymentsQueryHandler : IRequestHandler<GetWorkShiftsPaymentsQuery, IEnumerable<WorkShiftPaymentDto>>
{
	private readonly IWorkShiftPaymentRepository _repository;
	private readonly IMapper _mapper;

	public GetWorkShiftsPaymentsQueryHandler(IWorkShiftPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<WorkShiftPaymentDto>> Handle(GetWorkShiftsPaymentsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<WorkShiftPaymentDto>>(await _repository.Get(trackChanges: false));
}
