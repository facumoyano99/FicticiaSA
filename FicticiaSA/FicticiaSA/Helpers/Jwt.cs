using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FicticiaSA.Helpers.Config;
using FicticiaSA.Models.Dtos.UserDtos;

namespace FicticiaSA.Helpers
{
    public class Jwt
    {
        private readonly IConfig config;

        public Jwt(IConfig config)
        {
            this.config = config;
        }
        public UserTokenDto Construction(string userName, int idUser)
        {
            List<Claim> claims = new()
            {
                new Claim("user", userName),
                new Claim("idUser", idUser.ToString()),
            };

            SymmetricSecurityKey llave = new(Encoding.UTF8.GetBytes(config.GetJwt()));
            SigningCredentials creds = new(llave, SecurityAlgorithms.HmacSha256Signature);

            DateTime expiracion = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken securityToken = new(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new UserTokenDto()
            {
                Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiracion
            };
        }
    }
}
