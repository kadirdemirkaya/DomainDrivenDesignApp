using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Infrastructure.Configurations;
using FlavorWorld.Infrastructure.Settings.JwtSetting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSetting _jwtOptions;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtSetting> jwtOptions, IDateTimeProvider dateTimeProvider)
    {
        _jwtOptions = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user)
    {
        var siginingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret)),
            SecurityAlgorithms.HmacSha256
        );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.Username),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: jwtConfiguration.ValidIssuer,
            audience: jwtConfiguration.ValidAudience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(double.Parse(jwtConfiguration.ExpiryMinutes)),
            claims: claims,
            signingCredentials: siginingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}