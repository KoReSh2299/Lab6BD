using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto?>
{
	private readonly IDiscountRepository _repository;
	private readonly IMapper _mapper;

	public GetDiscountByIdQueryHandler(IDiscountRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<DiscountDto?> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<DiscountDto>(await _repository.GetById(request.Id, trackChanges: false));
}
