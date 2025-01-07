using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetWorkShiftPaymentByIdQueryHandler : IRequestHandler<GetWorkShiftPaymentByIdQuery, WorkShiftPaymentDto?>
{
	private readonly IWorkShiftPaymentRepository _repository;
	private readonly IMapper _mapper;

	public GetWorkShiftPaymentByIdQueryHandler(IWorkShiftPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WorkShiftPaymentDto?> Handle(GetWorkShiftPaymentByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<WorkShiftPaymentDto>(await _repository.GetById(request.Id, trackChanges: false));
}
