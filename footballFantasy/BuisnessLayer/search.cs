using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class search
    {
        public static bool filterCheking(int minPrice, int maxPrice, int Position, int minScore, int maxScore,int teamCode)
        {
            //check in price range
            //check position
            //check in range score
            //check team
        }
        public static List<Player> searchPlayers(string name, int minPrice, int maxPrice, int Position, int minScore, int maxScore, int teamCode)
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
