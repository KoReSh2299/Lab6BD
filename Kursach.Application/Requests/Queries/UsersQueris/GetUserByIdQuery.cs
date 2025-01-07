using Kursach.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Requests.Queries.UsersQueris
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto?>;
}
