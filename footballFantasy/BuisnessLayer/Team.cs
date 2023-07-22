using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer;

public class Team
{
    public static Player getNullPlayer()
    {
        Player player = new Player();
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

        return player;
    }
    public static Player getPlayerByCode(int code)
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
    public static List<Player> getAllPlayer(User user)
    {
        List<Player> list = new List<Player>();
        Player player = new Player();

        player = getPlayerByCode(user.outsideGK);
        list.Add(player);

        player = getPlayerByCode(user.outsideDEF);
        list.Add(player);

        player = getPlayerByCode(user.outsideMID);
        list.Add(player);

        player = getPlayerByCode(user.outsideFRW);
        list.Add(player);

        player = getPlayerByCode(user.insideGK);
        list.Add(player);

        foreach (var DEF in user.insideDEF)
        {
            player = getPlayerByCode(DEF);
            list.Add(player);
        }

        foreach (var MID in user.insideMID)
        {
            player = getPlayerByCode(MID);
            list.Add(player);
        }

        foreach (var FRW in user.insideFRW)
        {
            player = getPlayerByCode(FRW);
            list.Add(player);
        }

        return list;
    }

    public static void addplayer(int code, int budge, User user)
    {
        Player newPlayer = PlayerHandle.findPlayerByCode(code);
        budgetCheck(budge, newPlayer);
        playerExistanceCheck(newPlayer, user);
        teammatesNumCheck(newPlayer, user);
        positionCheck(newPlayer, user);

    }

    public static void positionCheck(Player newPlayer, User user)
    {
        if (newPlayer.element_type == 1)
        {
            addGK(newPlayer, user);
            return;
        }

        if (newPlayer.element_type == 2)
        {
            addDEF(newPlayer, user);
            return;
        }

        if (newPlayer.element_type == 3)
        {
            addMID(newPlayer, user);
            return;
        }

        if (newPlayer.element_type == 4)
        {
            addFRW(newPlayer, user);
            return;
        }
    }
    public static void teammatesNumCheck(Player newPlayer, User user)
    {
        int sameTeamNum = 0;
        if (getPlayerByCode(user.outsideGK).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(user.outsideDEF).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(user.outsideMID).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(user.outsideFRW).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        if (getPlayerByCode(user.insideGK).team == newPlayer.team)
        {
            sameTeamNum++;
        }

        foreach (var player in user.insideDEF)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in user.insideMID)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        foreach (var player in user.insideFRW)
        {
            if (getPlayerByCode(player).team == newPlayer.team)
            {
                sameTeamNum++;
            }
        }

        if (sameTeamNum >= 3)
        {
            throw new Exception("you cant add more than 3 player from same team");
        }
    }

    public static void playerExistanceCheck(Player newPlayer, User user)
    {
        foreach (var player in getAllPlayer(user))
        {
            if (player.code == newPlayer.code)
            {
                throw new Exception("this player already existed");
            }
        }
    }

    public static void budgetCheck(int budge, Player newPlayer)
    {
        if (budge < newPlayer.now_cost)
        {
            throw new Exception("you dont have enough mony");
        }
    }

    static void addGK(Player newPlayer, User user)
    {
        if (user.insideGK == -1)
        {
            user.insideGK = newPlayer.code;
            return;
        }
        if (user.outsideGK == -1)
        {
            user.outsideGK = newPlayer.code;
            return;
        }

        throw new Exception("you cant add goalkeeper to your team");
    }

    static void addDEF(Player newPlayer, User user)
    {
        for (int i = 0; i < 4; i++)
        {
            if (user.insideDEF[i] == -1)
            {
                user.insideDEF[i] = newPlayer.code;
                return;
            }
        }
        if (user.outsideDEF == -1)
        {
            user.outsideDEF = newPlayer.code;
            return;
        }
        throw new Exception("your cant add defender to your team");
    }

    static void addMID(Player newPlayer, User user)
    {
        for (int i = 0; i < 4; i++)
        {
            if (user.insideMID[i] == -1)
            {
                user.insideMID[i] = newPlayer.code;
                return;
            }
        }
        if (user.outsideMID == -1)
        {
            user.outsideMID = newPlayer.code;
            return;
        }
        throw new Exception("your cant add midfielder to your team");
    }

    static void addFRW(Player newPlayer, User user)
    {
        for (int i = 0; i < 2; i++)
        {
            if (user.insideFRW[i] == -1)
            {
                user.insideFRW[i] = newPlayer.code;
                return;
            }
        }
        if (user.outsideFRW == -1)
        {
            user.outsideFRW = newPlayer.code;
            return;
        }
        throw new Exception("your cant add forward to your team");
    }

    public static void deletePlayer(int code, User user)
    {
        if (user.insideGK == code)
        {
            user.insideGK = -1;
        }

        if (user.outsideGK == code)
        {
            user.outsideGK = -1;
        }

        if (user.outsideDEF == code)
        {
            user.outsideDEF = -1;
        }

        if (user.outsideMID == code)
        {
            user.outsideMID = -1;
        }

        if (user.outsideFRW == code)
        {
            user.outsideFRW = -1;
        }

        for (int i = 0; i < 4; i++)
        {
            if (user.insideDEF[i] == code)
            {
                user.insideDEF[i] = -1;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (user.insideMID[i] == code)
            {
                user.insideMID[i] = -1;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (user.insideFRW[i] == code)
            {
                user.insideFRW[i] = -1;
            }
        }
    }
    public static void swapPlayer(int code1, int code2, User user)
    {
        int temp;
        if (user.insideGK == code1 && user.outsideGK == code2)
        {
            temp = user.insideGK;
            user.insideGK = user.outsideGK;
            user.outsideGK = temp;
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            if (user.insideDEF[i] == code1 && user.outsideDEF == code2)
            {
                temp = user.insideDEF[i];
                user.insideDEF[i] = user.outsideDEF;
                user.outsideDEF = temp;
                return;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (user.insideMID[i] == code1 && user.outsideMID == code2)
            {
                temp = user.insideMID[i];
                user.insideMID[i] = user.outsideMID;
                user.outsideMID = temp;
                return;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (user.insideFRW[i] == code1 && user.outsideFRW == code2)
            {
                temp = user.insideFRW[i];
                user.insideFRW[i] = user.outsideFRW;
                user.outsideFRW = temp;
                return;
            }
        }
        throw new Exception("your player not exist or not same position");
    }
}