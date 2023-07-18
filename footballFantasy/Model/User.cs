using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using footballFantasy.BuisnessLayer;

namespace footballFantasy.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int budget { get; set; }
        public int weeklyPoint { get; set; }
        public int totalPoint { get; set; }

        public int outsideGK { get; set; }
        public int outsideDEF { get; set; }
        public int outsideMID { get; set; }
        public int outsideFRW { get; set; }
        public int insideGK { get; set; }
        public List<int> insideDEF { get; set; }
        public List<int> insideMID { get; set; }
        public List<int> insideFRW { get; set; }

        public User(string password, string name, string email, string userName)
        {
            this.name = name;
            this.email = email;
            this.userName = userName;
            this.password = password;
            this.budget = 1000;
            this.weeklyPoint = 0;
            this.totalPoint = 0;

            outsideGK = -1;
            outsideDEF = -1;
            outsideMID = -1;
            outsideFRW = -1;
            insideGK = -1;
            insideDEF = new List<int>();
            insideMID = new List<int>();
            insideFRW = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                insideDEF.Add(-1);
            }
            for (int i = 0; i < 4; i++)
            {
                insideMID.Add(-1);
            }
            for (int i = 0; i < 2; i++)
            {
                insideFRW.Add(-1);
            }
        }
        
    }
}
