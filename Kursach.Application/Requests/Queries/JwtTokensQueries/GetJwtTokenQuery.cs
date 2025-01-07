using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace Kursach.Application.Requests.Queries.JwtTokensQueries;

public record GetJwtTokenQuery(string Password, string Username) : IRequest<JwtSecurityToken?>;
