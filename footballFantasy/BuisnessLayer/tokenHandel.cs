using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace footballFantasy.BuisnessLayer
{
    public class tokenHandel
    {
        public static string Get_Token(string USERname)
        {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("powershell404sepehraHassanAmirSdeghjoon"));//its great to have long security key
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//convert security key to HASH code
            var claims = new[] //this unit is for decoding token 
            {
                new Claim("username",USERname),
            };
            var token = new JwtSecurityToken(//this unit is for identify the server whith can use our token ;this unit is json or better to sign it dictionary
                issuer: "http://localhost:12700",
                audience: "http://localhost:12700",
                claims,
                expires: DateTime.Now.AddHours(1),//exp time of token 
                signingCredentials: credentials  //that hash seckey
            );
            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);//convert token to string 
            return stringToken;
        }
        public static string decoding_Token(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var x = jsonToken.Claims.First(claim => claim.Type == "username").Value;
            return x.ToString();
        }
    }
}
