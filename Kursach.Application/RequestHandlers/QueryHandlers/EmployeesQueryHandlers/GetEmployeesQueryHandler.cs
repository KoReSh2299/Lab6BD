﻿using MediatR;
using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Queries;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
	private readonly IEmployeeRepository _repository;
	private readonly IMapper _mapper;

	public GetEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<EmployeeDto>>(await _repository.Get(trackChanges: false));
}
