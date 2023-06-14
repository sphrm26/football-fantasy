using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer;

public class Team
{
    public Player outsideGK { get; set; }
    public Player outsideDEF { get; set; }
    public Player outsideMID { get; set; }
    public Player outsideFRW { get; set; }
    public Player insideGK { get; set; }
    public List<Player> insideDEF { get; set; }
    public  List<Player> insideMID { get; set; }
    public  List<Player> insideFRW { get; set; }
    
}