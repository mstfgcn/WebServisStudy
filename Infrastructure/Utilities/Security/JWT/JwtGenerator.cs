using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Utilities.Security.JWT
{
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;
        private TokenOptions _tokenOptions;
        private DateTime _expirationDate;
        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions=_configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }

        public AccesToken GenerateAccesToken()
        {
            _expirationDate = DateTime.Now.AddMinutes(_tokenOptions.Expiration);


            var sKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            var sCrendtials = new SigningCredentials(sKey,SecurityAlgorithms.HmacSha256);

            var securiyToken = new JwtSecurityToken
                (
                issuer:_tokenOptions.Issuer,
                audience:_tokenOptions.Audience,
                expires:_expirationDate,
                notBefore:DateTime.Now,
                claims: new List<Claim> { new Claim("key1","value1"), new Claim("key2", "value2") , new Claim("key3", "value3") },
                signingCredentials: sCrendtials
                );

            var jwtHandler= new JwtSecurityTokenHandler();
            var token=jwtHandler.WriteToken(securiyToken);

            return new AccesToken()
            {
                Token = token,
                ExpirationDate = _expirationDate,
                Claims=null
            };

        }

    }
}
