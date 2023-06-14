using footballFantasy.Model;
using ServiceStack;
using System;

namespace footballFantasy.BuisnessLayer
{
    public class Response
    {
        public List<Player> elements { get; set; }
    }
    public class apiRequest
    {
      public int  json2csharp()
        {
            int num = 0;
            string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            var response = url.GetJsonFromUrl().FromJson<Response>();
            foreach (var player in response.elements)
            {
                num++;
            }
            return num;
        }
    }
}
