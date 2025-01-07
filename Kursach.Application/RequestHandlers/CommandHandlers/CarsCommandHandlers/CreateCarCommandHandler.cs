using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
{
	private readonly ICarRepository _repository;
	private readonly IMapper _mapper;

	public CreateCarCommandHandler(ICarRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Car>(request.Car));
		await _repository.SaveChangesAsync();
	}
}
