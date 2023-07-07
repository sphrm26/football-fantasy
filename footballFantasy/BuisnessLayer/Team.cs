using footballFantasy.Model;
using footballFantasy.DataAccessLayer;
namespace footballFantasy.BuisnessLayer;

public class Team
{
    public Player outsideGK { get; set; } 
    public Player outsideDEF { get; set; }
    public Player outsideMID { get; set; }
    public Player outsideFRW { get; set; }
    public Player insideGK { get; set; }
    public List<Player> insideDEF { get; set; }
    public List<Player> insideMID { get; set; }
    public List<Player> insideFRW { get; set; }
    public static void addplayer(string userName, int code)
    {
        var playerWantToAdd = handlePlayer.findPlayerByCode(code);
        var userWantToAdd = handelUserDatabase.findUserByUserName(userName);
    }
    public static void positionLimit()
    {
        
    }
    public static void positionCheck()
    {
        
    }
    public static void budgetCheck()
    {

    }
    public static void teammatesNumCheck()
    {
        
    }
}