using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries.UsersQueris;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.RequestHandlers.QueryHandlers;
public class GetUsersPageQueryHandler : IRequestHandler<GetUsersPageQuery, PaginatedList<UserDto>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUsersPageQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetUsersPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<UserDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, trackChanges: false));
}
