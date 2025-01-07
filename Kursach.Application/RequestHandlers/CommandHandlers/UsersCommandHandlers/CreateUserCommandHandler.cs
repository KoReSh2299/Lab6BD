using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateUserCommand>
{
	private readonly IUserRepository _repository = userRepository;
	private readonly IMapper _mapper = mapper;

	public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<User>(request.User));
		await _repository.SaveChangesAsync();
	}
}
