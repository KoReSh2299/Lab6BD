using Kursach.Application.Dtos;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Requests.Queries;

public record GetPaymentsPageQuery(PaymentFilter Filter, int PageIndex, int PageSize) : IRequest<PaginatedList<PaymentDto>>;

