using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand>
{
	private readonly IDiscountRepository _repository;
	private readonly IMapper _mapper;

	public CreateDiscountCommandHandler(IDiscountRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Discount>(request.Discount));
		await _repository.SaveChangesAsync();
	}
}
