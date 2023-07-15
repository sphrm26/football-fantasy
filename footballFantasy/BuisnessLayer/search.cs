using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class search
    {
        public static bool inPriceRange(int minPrice, int maxPrice, int price)
        {
            if (price >= minPrice && price <= maxPrice)
            {
                return true;
            }
            return false;
        }
        public static bool positionCheck(int position, int playerPosition)
        {
            if (position == 5)
            {
                return true;
            }
            if (position == playerPosition)
            {
                return true;
            }
            return false;
        }
        public static bool filterCheking(int minPrice, int maxPrice, int Position, int minScore, int maxScore, int teamCode, Player player)
        {
            //check in price range
            if (!inPriceRange(minPrice, maxPrice, player.now_cost))
            {
                return false;
            }

            //check position
            if (!positionCheck(Position, player.element_type))
            {
                return false;
            }

            //check in range score
            //check team
        }

        public static bool firstSame(string searched, string sourse)
        {

        }
        public static bool contain(string searched, string sourse)
        {

        }
        public static bool wordsInOrder(string searched, string sourse)
        {

        }
        public static bool haveWords(string searched, string sourse)
        {

        }

        public static int searchEngine(string name, string first_name, string second_name)
        {
            //to lover()
            //search by first name
            //search by first name
            //search by last name
            //search by last name
            //search by full name
            //search by full name
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
