using System.Linq.Expressions;
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

    public void addplayer(Player newPlayer)
    {
        budgetCheck(newPlayer);
        playerExistanceCheck(newPlayer);
        teammatesNumCheck(newPlayer);
        positionCheck(newPlayer);

    }

    public void positionCheck(Player newPlayer)
    {
        if (newPlayer.element_type == 1)
        {
            addGK(newPlayer);
        }

        if (newPlayer.element_type == 2)
        {
            addDEF(newPlayer);
        }

        if (newPlayer.element_type == 3)
        {
            addMID(newPlayer);
        }

        if (newPlayer.element_type == 4)
        {
            addFRW(newPlayer);
        }
    }

    public void budgetCheck(Player newPlayer)
    {
    }

    public void teammatesNumCheck(Player newPlayer)
    {
        int sameTeamNum = 0;
        if (outsideGK.team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (outsideDEF.team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (outsideMID.team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (outsideFRW.team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (insideGK.team == newPlayer.team)
        {
            sameTeamNum++;
        }

        foreach (var player in insideDEF)
        {
            if (player.team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in insideMID)
        {
            if (player.team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in insideFRW)
        {
            if (player.team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        if (sameTeamNum > 3)
        {
            throw new Exception("you cant add more than 3 player from same team");
        }
    }

    public void playerExistanceCheck(Player newPlayer)
    {
        
    }

    void addGK(Player newPlayer)
    {
        if (insideGK == null)
        {
            insideGK = newPlayer;
        }
        else
        {
            outsideGK = newPlayer;
        }
    }

    void addDEF(Player newPlayer)
    {
        if (insideDEF.Count < 4)
        {
            insideDEF.Add(newPlayer);
        }
        else
        {
            outsideDEF = newPlayer;
        }
    }

    void addMID(Player newPlayer)
    {
        if (insideMID.Count < 4)
        {
            insideMID.Add(newPlayer);
        }
        else
        {
            outsideMID = newPlayer;
        }
    }

    void addFRW(Player newPlayer)
    {
        if (insideFRW.Count < 2)
        {
            insideFRW.Add(newPlayer);
        }
        else
        {
            outsideFRW = newPlayer;
        }
    }
}