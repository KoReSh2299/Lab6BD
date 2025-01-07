using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateUserCommandHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<UpdateUserCommand, bool>
{
	private readonly IUserRepository _repository = repository;
	private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.User.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.User, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
