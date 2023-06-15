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
}