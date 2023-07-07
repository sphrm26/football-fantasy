using footballFantasy.Model;

namespace footballFantasy.DataAccessLayer;

public class handlePlayer
{
    public static Player? findPlayerByCode(int code)
    {   
        using (var db = new Database())
        {
            var record = db.Players.FirstOrDefault(record => record.code == code);
            return record;
        }
    }
}