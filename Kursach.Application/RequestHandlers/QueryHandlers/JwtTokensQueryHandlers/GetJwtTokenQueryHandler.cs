using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Queries;
using Kursach.Application.Requests.Queries.JwtTokensQueries;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.RequestHandlers.QueryHandlers;

public class GetJwtTokenQueryHandler : IRequestHandler<GetJwtTokenQuery, JwtSecurityToken?>
{
    private readonly IUserRepository _repository;

    public GetJwtTokenQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<JwtSecurityToken?> Handle(GetJwtTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByUsername(request.Username, false);

        if (user != null)
        {
            if(PasswordHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                // Создаем список утверждений (claims)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                // Создаем JWT токен
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return jwt;
            }
        }
            
        return null;
    }
}
