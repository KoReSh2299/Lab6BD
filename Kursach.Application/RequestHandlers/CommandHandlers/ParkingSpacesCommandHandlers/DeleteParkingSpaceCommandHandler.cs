﻿using MediatR;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class DeleteParkingSpaceCommandHandler(IParkingSpaceRepository repository) : IRequestHandler<DeleteParkingSpaceCommand, bool>
{
	private readonly IParkingSpaceRepository _repository = repository;

	public async Task<bool> Handle(DeleteParkingSpaceCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Id, trackChanges: false);

        if (entity is null)
        {
            return false;
        }

        _repository.Delete(entity);
        await _repository.SaveChangesAsync();

        return true;
	}
}