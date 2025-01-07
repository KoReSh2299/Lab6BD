using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateParkingSpaceCommandHandler : IRequestHandler<CreateParkingSpaceCommand>
{
	private readonly IParkingSpaceRepository _repository;
	private readonly IMapper _mapper;

	public CreateParkingSpaceCommandHandler(IParkingSpaceRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Handle(CreateParkingSpaceCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<ParkingSpace>(request.ParkingSpace));
		await _repository.SaveChangesAsync();
	}
}
