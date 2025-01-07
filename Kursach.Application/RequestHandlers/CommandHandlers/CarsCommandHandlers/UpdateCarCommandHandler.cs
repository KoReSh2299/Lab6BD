using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
{
	private readonly ICarRepository _repository;
	private readonly IMapper _mapper;

	public UpdateCarCommandHandler(ICarRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Car.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Car, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
