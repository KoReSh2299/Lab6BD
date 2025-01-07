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

    internal class GetEmployeesPageQueryHandler : IRequestHandler<GetEmployeesPageQuery, PaginatedList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeesPageQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EmployeeDto>> Handle(GetEmployeesPageQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<PaginatedList<EmployeeDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
    }