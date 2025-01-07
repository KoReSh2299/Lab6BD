using Kursach.Application.Dtos;
using Kursach.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Requests.Queries
{
    public record GetCarsQuery : IRequest<IEnumerable<CarDto>>;
}
