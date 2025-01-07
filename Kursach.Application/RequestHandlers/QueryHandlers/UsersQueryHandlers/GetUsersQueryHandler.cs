using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries.UsersQueris;
using Kursach.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserDto?>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUsersQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<UserDto>(await _repository.Get(trackChanges: false));
}
