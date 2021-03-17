using Core.Entities.Concrete;
using Core.Extentions;
using Core.Utilities.Security.Encryiption;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //appsettings deki dosyaları okumaya yarar.
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user, List<UserClaimDto> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(user, signingCredentials, operationClaims, _tokenOptions);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            var accessToken = new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token
            };
            return accessToken;
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signingCredentials, List<UserClaimDto> operationClaims, TokenOptions tokenOptions)
        {
            var result = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: _accessTokenExpiration,
                signingCredentials: signingCredentials,
                claims: GenerateTypeToInumerable(user,operationClaims)
                );
            return result;
        }

        public IEnumerable<Claim> GenerateTypeToInumerable(User user, List<UserClaimDto> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddId(user.Id.ToString());
            claims.AddFullName(user.FirstName, user.LastName);
            claims.AddMail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
