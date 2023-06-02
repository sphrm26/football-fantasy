namespace footballFantasy.PresentationLayer
{
    public class login
    {
        public static string Get_Token(string USERname)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("powershell404sepehraHassanAmirSdeghjoon"));//its great to have long security key
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
        public static string login(string username, string password)
        {
            public static string signup(string name, string email, string username, string password)
            {
                using (var db = new Database())
                {
                    foreach (var user in db.users)
                    {
                        if (username == user.userName&&password==user.passWord)
                        {
                            string token = Get_Token(username, password);
                            return token;
                        }
                    }
                }
            }
        }
