using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateParkingSpaceCommandHandler : IRequestHandler<UpdateParkingSpaceCommand, bool>
{
	private readonly IParkingSpaceRepository _repository;
	private readonly IMapper _mapper;

	public UpdateParkingSpaceCommandHandler(IParkingSpaceRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateParkingSpaceCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.ParkingSpace.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.ParkingSpace, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
