﻿using System.ComponentModel.DataAnnotations;
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
        public Team team { get; set; }

        public User(string password, string name, string email, string userName)
        {
            this.team = new Team();
            this.name = name;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }
    }

}
