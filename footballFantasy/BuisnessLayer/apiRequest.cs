using footballFantasy.DataAccessLayer;
using footballFantasy.Model;
using Newtonsoft.Json;
using RestSharp;
using ServiceStack;
using System;
using static ServiceStack.HttpContextFactory;

namespace footballFantasy.BuisnessLayer
{
    public class Response
    {
        public List<Player> player_seter { get; set; }
    }
    public class apiRequest
    {
        public static void json2csharp()
        {
            var client = new RestClient("https://fantasy.premierleague.com");
            var request = new RestRequest("/api/bootstrap-static/", Method.Get);
            var response = client.Execute(request);
            var json = response.Content;
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            var elements = data["elements"];
            var players = JsonConvert.DeserializeObject<List<Player>>(elements.ToString());
            PlayerHandle.SavingPlayrToDb(players);
            List<Player> list = players;
            foreach (var element in list)
            {
                Console.WriteLine($"firs_name: {element.first_name}");
                Console.WriteLine($"second_name: {element.second_name}");
                Console.WriteLine($"code: {element.code}");
                Console.WriteLine($"id: {element.id}");
                Console.WriteLine($"element_type: {element.element_type}");
                Console.WriteLine($"now_cost: {element.now_cost}");
                Console.WriteLine($"team: {element.team}");
                Console.WriteLine("");
            }
            Console.WriteLine(list.Count);
        }
    }
}
