using footballFantasy.Model;

namespace footballFantasy.DataAccessLayer;

public class PlayerHandle
{
    public static void SavingPlayrToDb(List<Player> newPlayers)
    {
        using (var db = new Database())
        {
            foreach (var player  in db.Players)
            {
                db.Players.Remove(player);
            }
            
            foreach (var player in newPlayers)
            {
                db.Players.Add(player);
            }
            db.SaveChanges();
        } 
    }

    public static Player? findPlayerByCode(int code)
    {
        using (var db = new Database())
        {
            var record = db.Players.FirstOrDefault(record => record.code == code);
            return record;
        }
    }

    public static List<Player> GetAllPlayers()
    {
        List<Player> list = new List<Player>();
        using (var db = new Database())
        {
            foreach (var player in db.Players)
            {
                list.Add(player);
            }
        }
        return list;
    }
}