using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class search
    {
        public static List<Player> searchPlayers()
        {
            List<Player> list = new List<Player>();
            List<Player> players = DataAccessLayer.PlayerHandle.GetAllPlayers();
            foreach (var player in players)
            {
                // checking filters
                // call search engine
                // add to list
            }
            return list;
        }
    }
}
