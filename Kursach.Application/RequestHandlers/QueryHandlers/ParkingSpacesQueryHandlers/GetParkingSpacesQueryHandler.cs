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

public class GetParkingSpacesQueryHandler : IRequestHandler<GetParkingSpacesQuery, IEnumerable<ParkingSpaceDto>>
{
    private readonly IParkingSpaceRepository _repository;
    private readonly IMapper _mapper;

    public GetParkingSpacesQueryHandler(IParkingSpaceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ParkingSpaceDto>> Handle(GetParkingSpacesQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<IEnumerable<ParkingSpaceDto>>(await _repository.Get(false));
}
