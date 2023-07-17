using footballFantasy.DataAccessLayer;
using footballFantasy.Model;
using System.ComponentModel.DataAnnotations;

namespace footballFantasy.BuisnessLayer;

public class Team
{
    [Key]
    public string teamID { get; set; }
    public int outsideGK { get; set; }
    public int outsideDEF { get; set; }
    public int outsideMID { get; set; }
    public int outsideFRW { get; set; }
    public int insideGK { get; set; }
    public List<int> insideDEF { get; set; }
    public List<int> insideMID { get; set; }
    public List<int> insideFRW { get; set; }

    public Team() { }

    public Team(string id)
    {
        teamID = id;
    }
    public Player getNullPlayer()
    {
        Player player = new Player();
        if (player == null)
        {
            player = new Player();
            player.code = -1;
            player.first_name = "null";
            player.id = -1;
            player.now_cost = -1;
            player.second_name = "null";
            player.team = -1;
            player.element_type = -1;
            player.event_points = -1;
            player.total_points = -1;
        }
        return player;
    }
    public Player getPlayerByCode(int code)
    {
        Player player = new Player();
        player = PlayerHandle.findPlayerByCode(code);
        if (player == null)
        {
            player = new Player();
            player.code = -1;
            player.first_name = "null";
            player.id = -1;
            player.now_cost = -1;
            player.second_name = "null";
            player.team = -1;
            player.element_type = -1;
            player.event_points = -1;
            player.total_points = -1;
        }
        return player;
    }
    public List<Player> getAllPlayer()
    {
        List<Player> list = new List<Player>();
        Player player = new Player();

        player = getPlayerByCode(outsideGK);
        list.Add(player);

        player = getPlayerByCode(outsideDEF);
        list.Add(player);

        player = getPlayerByCode(outsideMID);
        list.Add(player);

        player = getPlayerByCode(outsideFRW);
        list.Add(player);

        player = getPlayerByCode(insideGK);
        list.Add(player);

        foreach (var DEF in insideDEF)
        {
            player = getPlayerByCode(DEF);
            list.Add(player);
        }

        foreach (var MID in insideMID)
        {
            player = getPlayerByCode(MID);
            list.Add(player);
        }

        foreach (var FRW in insideFRW)
        {
            player = getPlayerByCode(FRW);
            list.Add(player);
        }

        return list;
    }

    public void addplayer(int code, int budge)
    {
        Player newPlayer = PlayerHandle.findPlayerByCode(code);
        budgetCheck(budge, newPlayer);
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
    public void teammatesNumCheck(Player newPlayer)
    {
        int sameTeamNum = 0;
        if (getPlayerByCode(outsideGK).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(outsideDEF).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(outsideMID).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(outsideFRW).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(insideGK).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        foreach (var player in insideDEF)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in insideMID)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in insideFRW)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
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
        foreach (var pleter in getAllPlayer())
        {
            if (pleter.code == newPlayer.code)
            {
                throw new Exception("this player already existed");
            }
        }
    }

    public void budgetCheck(int budge, Player newPlayer)
    {
        if (budge < newPlayer.now_cost)
        {
            throw new Exception("you dont have enough mony");
        }
    }

    void addGK(Player newPlayer)
    {
        if (getPlayerByCode(insideGK) == getNullPlayer())
        {
            insideGK = newPlayer.code;
            return;
        }
        if (getPlayerByCode(outsideGK) == getNullPlayer())
        {
            outsideGK = newPlayer.code;
            return;
        }

        throw new Exception("you cant add goalkeeper to your team");
    }

    void addDEF(Player newPlayer)
    {
        for(int i = 0; i < 4; i++)
        {
            if (getPlayerByCode(insideDEF[i]) == getNullPlayer())
            {
                insideDEF[i] = newPlayer.code;
                return;
            }
        }
        if (getPlayerByCode(outsideDEF) == getNullPlayer())
        {
            outsideDEF = newPlayer.code;
        }
        throw new Exception("your cant add defender to your team");
    }

    void addMID(Player newPlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (getPlayerByCode(insideMID[i]) == getNullPlayer())
            {
                insideMID[i] = newPlayer.code;
                return;
            }
        }
        if (getPlayerByCode(outsideMID) == getNullPlayer())
        {
            outsideMID = newPlayer.code;
        }
        throw new Exception("your cant add midfielder to your team");
    }

    void addFRW(Player newPlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (getPlayerByCode(insideFRW[i]) == getNullPlayer())
            {
                insideFRW[i] = newPlayer.code;
                return;
            }
        }
        if (outsideFRW == null)
        {
            outsideFRW = newPlayer.code;
        }
        throw new Exception("your cant add forward to your team");
    }

    public void deletePlayer(int code)
    {
        Player player = PlayerHandle.findPlayerByCode(code);
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
    public void swapPlayer(int code1, int code2)
    {
        Player temp;
        if (insideGK.code == code1 && outsideGK.code == code2)
        {
            temp = insideGK;
            insideGK = outsideGK;
            outsideGK = temp;
        }
        foreach (var p1 in insideDEF)
        {
            if (p1.code == code1 && outsideDEF.code == code2)
            {
                temp = p1;
                insideDEF.Remove(p1);
                insideDEF.Add(outsideDEF);
                outsideDEF = temp;
            }
        }
        foreach (var p1 in insideMID)
        {
            if (p1.code == code1 && outsideMID.code == code2)
            {
                temp = p1;
                insideMID.Remove(p1);
                insideMID.Add(outsideMID);
                outsideMID = temp;
            }
        }
        foreach (var p1 in insideFRW)
        {
            if (p1.code == code1 && outsideFRW.code == code2)
            {
                temp = p1;
                insideFRW.Remove(p1);
                insideFRW.Add(outsideFRW);
                outsideFRW = temp;
            }
        }
        throw new Exception("your player not exist or not same position");
    }
}