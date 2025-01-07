using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<PaymentDto>>
{
	private readonly IPaymentRepository _repository;
	private readonly IMapper _mapper;

	public GetPaymentsQueryHandler(IPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<PaymentDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<PaymentDto>>(await _repository.Get(trackChanges: false));
}
