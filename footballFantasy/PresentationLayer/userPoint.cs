using footballFantasy.Model;

namespace footballFantasy.PresentationLayer;

public class userPoint
{
    public static void calculatePoint()
    {
        BuisnessLayer.UserHandel.calculateAllUsersPoint();
    }

    public static List<object> tablePoint(int index, int length)
    {
        var users = BuisnessLayer.UserHandel.pointTable();
        users = BuisnessLayer.pagination.paging<User>(users, index, length);
        List<object> temp = new List<object>();
        foreach (var u1 in users)
        {
            temp.Add(new
            {
                username = u1.userName,
                point = Convert.ToString(u1.weeklyPoint)
            });
        }
        return temp;
    }
}