using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetDiscountsQueryHandler : IRequestHandler<GetDiscountsQuery, IEnumerable<DiscountDto>>
{
	private readonly IDiscountRepository _repository;
	private readonly IMapper _mapper;

	public GetDiscountsQueryHandler(IDiscountRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<DiscountDto>> Handle(GetDiscountsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<DiscountDto>>(await _repository.Get(trackChanges: false));
}
