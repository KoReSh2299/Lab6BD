using Kursach.Application.Dtos;
using Kursach.Domain.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Requests.Queries.UsersQueris
{
    public record GetUsersQuery : IRequest<UserDto?>;
}
