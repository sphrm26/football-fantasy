namespace footballFantasy.BuisnessLayer
{
    public class Class
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream resStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        string str = reader.ReadToEnd();
    }
}
