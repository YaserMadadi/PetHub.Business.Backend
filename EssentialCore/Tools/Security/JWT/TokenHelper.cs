using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.ExtenssionMethod;
using EssentialCore.Tools.Security.Entities;

namespace EssentialCore.Tools.Security.JWT
{
    public class TokenHelper : ITokenHelper
    {
        private IConfiguration configuration;

        private TokenConfig tokenConfig;

        public TokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;

            tokenConfig = (TokenConfig)this.configuration.GetSection("TokenConfig");
        }

        public AccessToken CreateToken(UserCredit userCredit)
        {
            var accsessTokenExpiration = DateTime.Now.AddMinutes(tokenConfig.AccessTokenExpiration);

            var key = SecurityExtension.CreateSecurityKey(tokenConfig.SecurityKey);

            var signingCredentials = key.CreateSigningCredentials();

            var jwt = CreateJwtSecurityToken(userCredit, signingCredentials);

            var jwtTokenHandler = new JwtSecurityTokenHandler();



            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Id = 1,
                Token = token,
                ExpireTime = accsessTokenExpiration,
                DisplayName = userCredit.DisplayName,
                Employee_Id = userCredit.Employee_Id,
                Person_Id = userCredit.Person_Id
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(UserCredit userCredit, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenConfig.Issuer,
                audience: tokenConfig.Audience,
                expires: DateTime.Now.AddMinutes(tokenConfig.AccessTokenExpiration),
                notBefore: DateTime.Now,
                claims: setClaim(userCredit),
                signingCredentials: signingCredentials
                );

            return jwt;
        }
        private IEnumerable<Claim> setClaim(UserCredit userCredit)
        {
            var claims = new List<Claim>();

            claims.AddEmail(userCredit.UserName);

            claims.AddUserName(userCredit.UserName);

            claims.AddUser_Id(userCredit.UserAccount_Id);

            return claims;
        }
    }
}
