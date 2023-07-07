﻿using footballFantasy.Model;

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

    public List<Player> getAllPlater()
    {
        List<Player> list = new List<Player>();
        list.Add(outsideGK);
        list.Add(outsideDEF);
        list.Add(outsideMID);
        list.Add(outsideFRW);
        list.Add(insideGK);
        foreach (var DEF in insideDEF)
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
        else if(outsideGK == null)
        {
            outsideGK = newPlayer;
        }

        throw new Exception("you cant add goalkeeper to your team");
    }

    void addDEF(Player newPlayer)
    {
        if (insideDEF.Count < 4)
        {
            insideDEF.Add(newPlayer);
        }
        else if(outsideDEF == null)
        {
            outsideDEF = newPlayer;
        }
        throw new Exception("your cant add defender to your team");
    }

    void addMID(Player newPlayer)
    {
        if (insideMID.Count < 4)
        {
            insideMID.Add(newPlayer);
        }
        else if(outsideMID == null)
        {
            outsideMID = newPlayer;
        }
        throw new Exception("your cant add midfielder to your team");
    }

    void addFRW(Player newPlayer)
    {
        if (insideFRW.Count < 2)
        {
            insideFRW.Add(newPlayer);
        }
        else if(outsideFRW == null)
        {
            outsideFRW = newPlayer;
        }
        throw new Exception("your cant add forward to your team");
    }

    public void deletePlayer(Player player)
    {
        if (insideGK.code == player.code)
        {
            insideGK = null;
        }

        if (outsideGK.code == player.code)
        {
            outsideGK = null;
        }

        if (outsideDEF.code == player.code)
        {
            outsideDEF = null;
        }

        if (outsideMID.code == player.code)
        {
            outsideMID = null;
        }

        if (outsideFRW.code == player.code)
        {
            outsideFRW = null;
        }

        foreach (var item in insideDEF)
        {
            if (item.code == player.code)
            {
                insideDEF.Remove(item);
            }
        }

        foreach (var item in insideMID)
        {
            if (item.code == player.code)
            {
                insideMID.Remove(item);
            }
        }

        foreach (var item in insideFRW)
        {
            if (item.code == player.code)
            {
                insideFRW.Remove(item);
            }
        }
    }
}