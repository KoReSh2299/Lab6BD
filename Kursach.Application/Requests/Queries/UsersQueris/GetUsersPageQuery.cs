﻿using Kursach.Application.Dtos;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Requests.Queries.UsersQueris
{
    public record GetUsersPageQuery(UserFilter Filter, int PageIndex, int PageSize) : IRequest<PaginatedList<UserDto>>;
}
