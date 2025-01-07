using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetClientsFilteredPageQueryHandler(IClientRepository repository, IMapper mapper) : IRequestHandler<GetClientsPageQuery, PaginatedList<ClientDto>>
{
    private readonly IClientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<ClientDto>> Handle(GetClientsPageQuery request, CancellationToken cancellationtoken) =>
        _mapper.Map<PaginatedList<ClientDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}
