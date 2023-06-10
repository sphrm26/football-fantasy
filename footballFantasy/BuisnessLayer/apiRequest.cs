using System.Net;

namespace footballFantasy.BuisnessLayer
{
    public class Class
    {
        public static string request()
        {
            string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
    }
}
