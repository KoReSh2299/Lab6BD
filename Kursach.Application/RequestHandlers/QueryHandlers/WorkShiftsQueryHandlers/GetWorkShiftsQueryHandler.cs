using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetWorkShiftsQueryHandler : IRequestHandler<GetWorkShiftsQuery, IEnumerable<WorkShiftDto>>
{
	private readonly IWorkShiftRepository _repository;
	private readonly IMapper _mapper;

	public GetWorkShiftsQueryHandler(IWorkShiftRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<WorkShiftDto>> Handle(GetWorkShiftsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<WorkShiftDto>>(await _repository.Get(trackChanges: false));
}
