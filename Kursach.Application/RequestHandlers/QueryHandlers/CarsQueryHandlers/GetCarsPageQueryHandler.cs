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

namespace Kursach.Application.RequestHandlers.QueryHandlers
{
    public class GetCarsPageQueryHandler : IRequestHandler<GetCarsPageQuery, PaginatedList<CarDto>>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarsPageQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CarDto>> Handle(GetCarsPageQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<PaginatedList<CarDto>>(await _repository.GetFilteredPageAsync(request.PageIndex, request.PageSize, request.Filter, false));
    }
}
