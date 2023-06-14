using footballFantasy.Model;
using ServiceStack;
using System;

namespace footballFantasy.BuisnessLayer
{
    public class Response
    {
        public List<Player> player_seter { get; set; }
    }
    public class apiRequest
    {
      public void  json2csharp()
        {
 
            string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            var response = url.GetJsonFromUrl().FromJson<Response>();
        }
    }
}
