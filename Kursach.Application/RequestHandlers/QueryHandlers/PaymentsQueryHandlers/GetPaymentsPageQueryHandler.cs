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

public class GetPaymentsPageQueryHandler(IPaymentRepository repository, IMapper mapper) : IRequestHandler<GetPaymentsPageQuery, PaginatedList<PaymentDto>>
{
    private readonly IPaymentRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<PaymentDto>> Handle(GetPaymentsPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<PaymentDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
}
