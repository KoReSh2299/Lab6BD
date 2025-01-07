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
public class GetWorkShiftsPaymentsPageQueryHandler(IWorkShiftPaymentRepository repository, IMapper mapper) : IRequestHandler<GetWorkShiftsPaymentsPageQuery, PaginatedList<WorkShiftPaymentDto>>
{
    private readonly IWorkShiftPaymentRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<WorkShiftPaymentDto>> Handle(GetWorkShiftsPaymentsPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<WorkShiftPaymentDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}