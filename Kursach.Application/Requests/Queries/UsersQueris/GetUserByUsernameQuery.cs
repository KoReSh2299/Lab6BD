using Kursach.Application.Dtos;
using MediatR;

namespace Kursach.Application.Requests.Queries.UsersQueris
{
    public record GetUserByUsernameQuery(string Username) : IRequest<UserDto?>;
}
