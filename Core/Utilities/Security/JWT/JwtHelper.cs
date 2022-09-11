using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{

    //Configuration dosyasından(Wep API jsonsettings.json) değerleri okuyacak
    //Kullanıcıya kullanıcı bilgileri ve claimlerine göre token oluşturacak
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //set edilemez readonly
        private TokenOptions _tokenOptions; //appsettings.json'daki bilgilerin tutulacağı class
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration; //appsettings'deki bilgileri Configuration'a aktarılır/okunur
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //Section appsettings'deki {} arası
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //SecurityKeyHelper nesnesinin sebebi direk oradan çekebilmek için
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            //Token oluşturuldu
            //Handler ile token yazdırılır
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials,
            List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, //Eğer token'ın expiration bilgisi şuandan öncesese geçerli değil
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //Aşağıdaki methodlar için Extensions yapılır
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;

        }
    }
}
