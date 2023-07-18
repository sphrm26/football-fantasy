using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class search
    {
        public static List<Object> searchSndFilter(string name, int minPrice, int maxPrice, int position, int minScore, int maxScore, int teamCode, int sortBy, int order, int index, int length)
        {
            List<Player> list = BuisnessLayer.search.searchPlayers(name, minPrice, maxPrice, position, minScore, maxScore, teamCode);
            //sort
            list = BuisnessLayer.pagination.paging<Player>(list, index, length);
            List<Object> result = new List<Object>();
            foreach (Player player in list)
            {
                result.Add(new
                {
                    code = player.code,
                    first_name = player.first_name,
                    second_name = player.second_name,
                    total_points = player.total_points,
                    now_cost = player.now_cost,
                    taem = player.team
                });
            }
            return result;
        }
    }
}
