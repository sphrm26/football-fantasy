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
    public List<Player> getAllPlater()
    {
        List<Player> list = new List<Player>();
        list.Add(outsideGK);
        list.Add(outsideDEF);
        list.Add(outsideMID);
        list.Add(outsideFRW);
        list.Add(insideGK);
        foreach(var DEF in insideDEF)
        {
            list.Add(DEF);
        }
        foreach (var MID in insideMID)
        {
            list.Add(MID);
        }
        foreach (var FRW in insideFRW)
        {
            list.Add(FRW);
        }
        return list;
    }


}