using footballFantasy.Model;

namespace footballFantasy.PresentationLayer;

public class userPoint
{
    public static void calculatePoint()
    {
        BuisnessLayer.UserHandel.calculateAllUsersPoint();
    }
}