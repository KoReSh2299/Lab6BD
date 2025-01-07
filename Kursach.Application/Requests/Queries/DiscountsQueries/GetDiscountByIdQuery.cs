using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetDiscountByIdQuery(int Id) : IRequest<DiscountDto?>;
