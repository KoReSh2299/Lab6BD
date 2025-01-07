using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<CreateEmployeeCommand>
{
	private readonly IEmployeeRepository _repository = repository;
	private readonly IMapper _mapper = mapper;

    public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		await _repository.Create(_mapper.Map<Employee>(request.Employee));
		await _repository.SaveChangesAsync();
	}
}
