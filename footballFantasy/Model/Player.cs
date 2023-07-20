using System.ComponentModel.DataAnnotations;

namespace footballFantasy.Model;

public class Player
{
    [Key]
    public int code { get; set; }
    public string first_name { get; set; }
    public int id { get; set; }
    public int now_cost { get; set; }
    public string second_name { get; set; }
    public int team { get; set; }
    public int team_code { get; set; }
    public int element_type { get; set; }
    public int event_points { get; set; }
    public int total_points { get; set;}
}