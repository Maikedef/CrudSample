using CrudSample.Domain.Entities.Usuarios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace CrudSample.Application.Services.Token
{
    public class TokenService
    {
        private readonly string _chaveSeguranca;
        private readonly double _tempoExpiracaoTokenMinuto;
        public string TipoToken => "Bearer";

        public TokenService(string chaveSeguranca, double tempoExpiracaoTokenMinuto)
        {
            _chaveSeguranca = chaveSeguranca;
            _tempoExpiracaoTokenMinuto = tempoExpiracaoTokenMinuto;
        }

        public string GerarToken(Usuario? usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_tempoExpiracaoTokenMinuto),
                SigningCredentials = new SigningCredentials(SymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parametrosValidacao = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                IssuerSigningKey = SymmetricKey(),
                ClockSkew = new TimeSpan(0),
                ValidateIssuer = true,
                ValidateAudience = false
            };

            tokenHandler.ValidateToken(token, parametrosValidacao, out _);
        }

        private SymmetricSecurityKey SymmetricKey()
        {
            var symmetricKey = Convert.FromBase64String(_chaveSeguranca);
            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
