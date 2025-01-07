using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using MediatR;

namespace Kursach.Application.RequestHandlers.QueryHandlers.WorkShiftsQueryHandlers
{
    public class GetEmployeeWorkSummaryQueryHandler : IRequestHandler<GetEmployeeWorkSummaryPageQuery, PaginatedList<EmployeeWorkSummaryDto>>
    {
        private readonly IWorkShiftRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeWorkSummaryQueryHandler(IWorkShiftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EmployeeWorkSummaryDto>> Handle(GetEmployeeWorkSummaryPageQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<PaginatedList<EmployeeWorkSummaryDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
    }
}
