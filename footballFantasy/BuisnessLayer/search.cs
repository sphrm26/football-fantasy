using footballFantasy.Model;
using System.Text.RegularExpressions;

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
        public static bool inPointRange(int minPoint, int maxPoint, int playerPoint)
        {
            if (playerPoint >= minPoint && playerPoint <= maxPoint)
            {
                return true;
            }
            return false;
        }
        public static bool teamCheck(int team, int playerTeam)
        {
            if (team == 21)
            {
                return true;
            }
            if (team == playerTeam)
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
            if (!inPointRange(minScore, maxScore, player.total_points))
            {
                return false;
            }

            //check team
            if (!teamCheck(teamCode, player.team))
            {
                return false;
            }

            //filter check pass
            return true;
        }

        public static bool firstSame(string searched, string sourse)
        {
            string pattern = "^" + Regex.Escape(searched);
            Regex regex = new Regex(pattern);

            return regex.IsMatch(sourse);
        }
        public static bool contain(string searched, string sourse)
        {
            return sourse.Contains(searched);
        }
        public static bool dictationProblem(string searched, string sourse)
        {
            if (searched.Length > sourse.Length)
            {
                string temp = sourse;
                sourse = searched;
                searched = temp;
            }
            int counter = 0;
            for (int i = 0; i < searched.Length; i++)
            {
                if (searched[i] != sourse[i])
                {
                    counter++;
                }
            }
            if (counter <= 2)
            {
                return true;
            }
            return false;
        }
        public static bool wordsInOrder(string searched, string sourse)
        {
            string pattern = "^.*?" + string.Join(".*?", searched.ToCharArray()) + ".*?$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(sourse);
        }
        public static bool haveWords(string searched, string sourse)
        {
            foreach (var ch in searched)
            {
                if (!sourse.Contains(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static int searchEngine(string name, string first_name, string second_name)
        {
            name = name.ToLower();
            first_name = first_name.ToLower();
            second_name = second_name.ToLower();

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
                if (!filterCheking(minPrice, maxPrice, Position, minScore, maxScore, teamCode, player))
                {
                    continue;
                }

                // call search engine
                // add to list
            }
            return list;
        }
    }
}
