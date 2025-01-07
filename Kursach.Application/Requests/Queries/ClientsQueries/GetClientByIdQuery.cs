using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Queries;

public record GetClientByIdQuery(int Id) : IRequest<ClientDto?>;
