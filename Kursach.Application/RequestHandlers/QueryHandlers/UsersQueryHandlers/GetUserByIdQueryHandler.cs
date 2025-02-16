﻿using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries;
using Kursach.Application.Requests.Queries.UsersQueris;
using Kursach.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<UserDto>(await _repository.GetById(request.Id, trackChanges: false));
}
