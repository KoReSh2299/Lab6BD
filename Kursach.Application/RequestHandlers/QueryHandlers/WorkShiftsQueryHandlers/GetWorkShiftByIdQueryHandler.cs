using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetWorkShiftByIdQueryHandler : IRequestHandler<GetWorkShiftByIdQuery, WorkShiftDto?>
{
	private readonly IWorkShiftRepository _repository;
	private readonly IMapper _mapper;

	public GetWorkShiftByIdQueryHandler(IWorkShiftRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WorkShiftDto?> Handle(GetWorkShiftByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<WorkShiftDto>(await _repository.GetById(request.Id, trackChanges: false));
}
