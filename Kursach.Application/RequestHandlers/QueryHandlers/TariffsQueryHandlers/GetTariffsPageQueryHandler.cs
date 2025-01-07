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

public class GetTariffsPageQueryHandler(ITariffRepository repository, IMapper mapper) : IRequestHandler<GetTariffsPageQuery, PaginatedList<TariffDto>>
{
    private readonly ITariffRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<TariffDto>> Handle(GetTariffsPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<TariffDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}