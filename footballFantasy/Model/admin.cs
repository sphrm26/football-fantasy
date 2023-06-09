namespace footballFantasy.Model
{
    public class admin
    {
        public string Name { get; set; }
        public string password { get; set; }
        public admin(string name,string password)
        {
            this.Name = name;
            this.password = password;
        }
    }
}
