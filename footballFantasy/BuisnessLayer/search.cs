using footballFantasy.Model;
using System.Text.RegularExpressions;

namespace footballFantasy.BuisnessLayer
{
    public class search
    {
        public static bool inPriceRange(int minPrice, int maxPrice, int price)
        {
            if (maxPrice == -1)
            {
                return true;
            }
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
            if(maxPoint == -1)
            {
                return true;
            }
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
            if(searched.Length < 6)
            {
                return false;
            }
            int counter = 0;
            for (int i = 0; i < searched.Length; i++)
            {
                if (searched[i] != sourse[i])
                {
                    counter++;
                }
            }
            if (counter == 2 || counter == 1)
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

        public static int? searchPriority(string searched, string sourse)
        {
            if (firstSame(searched, sourse))
            {
                return 1;
            }
            if (contain(searched, sourse))
            {
                return 2;
            }
            if (dictationProblem(searched, sourse))
            {
                return 3;
            }
            if (wordsInOrder(searched, sourse))
            {
                return 4;
            }
            if (haveWords(searched, sourse))
            {
                return 5;
            }
            return null;

        }

        public static int? searchEngine(string name, string first_name, string second_name)
        {
            name = name.ToLower();
            first_name = first_name.ToLower();
            second_name = second_name.ToLower();

            int? result = new int();

            //search by first name
            result = searchPriority(name, first_name);
            if (result != null)
            {
                return result;
            }

            //search by first name
            result = searchPriority(first_name, name);
            if (result != null)
            {
                return result;
            }

            //search by last name
            result = searchPriority(name, second_name);
            if (result != null)
            {
                return result;
            }

            //search by last name
            result = searchPriority(second_name, name);
            if (result != null)
            {
                return result;
            }

            //search by full name
            result = searchPriority(name, first_name + " " + second_name);
            if (result != null)
            {
                return result;
            }

            //search by full name
            result = searchPriority(first_name + " " + second_name, name);
            if (result != null)
            {   
                return result;
            }

            return null;

        }

        public static List<Player> searchPlayers(string name, int minPrice, int maxPrice, int Position, int minScore, int maxScore, int teamCode)
        {
            List<Player> list = new List<Player>();
            List<Player> tempList1 = new List<Player>();
            List<Player> tempList2 = new List<Player>();
            List<Player> tempList3 = new List<Player>();
            List<Player> tempList4 = new List<Player>();
            List<Player> tempList5 = new List<Player>();
            List<Player> players = DataAccessLayer.PlayerHandle.GetAllPlayers();
            foreach (var player in players)
            {
                // checking filters
                if (!filterCheking(minPrice, maxPrice, Position, minScore, maxScore, teamCode, player))
                {
                    continue;
                }

                // add to list
                int? result = searchEngine(name, player.first_name, player.second_name);
                if (result == null)
                {
                    continue;
                }
                if (result == 1)
                {
                    tempList1.Add(player);
                }
                if (result == 2)
                {
                    tempList2.Add(player);
                }
                if (result == 3)
                {
                    tempList3.Add(player);
                }
                if (result == 4)
                {
                    tempList4.Add(player);
                }
                if (result == 5)
                {
                    tempList5.Add(player);
                }
            }
            list.AddRange(tempList1);
            list.AddRange(tempList2);
            list.AddRange(tempList3);
            list.AddRange(tempList4);
            list.AddRange(tempList5);
            return list;
        }
    }
}
