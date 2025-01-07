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
public class GetWorkShiftsPageQueryHandler(IWorkShiftRepository repository, IMapper mapper) : IRequestHandler<GetWorkShiftsPageQuery, PaginatedList<WorkShiftDto>>
{
    private readonly IWorkShiftRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<WorkShiftDto>> Handle(GetWorkShiftsPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<WorkShiftDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}
