using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto?>
{
	private readonly IPaymentRepository _repository;
	private readonly IMapper _mapper;

	public GetPaymentByIdQueryHandler(IPaymentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<PaymentDto?> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<PaymentDto>(await _repository.GetById(request.Id, trackChanges: false));
}
