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

public class GetDiscountsPageQueryHandler(IDiscountRepository repository, IMapper mapper) : IRequestHandler<GetDiscountsPageQuery, PaginatedList<DiscountDto>>
{
    private readonly IDiscountRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<DiscountDto>> Handle(GetDiscountsPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<DiscountDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}
