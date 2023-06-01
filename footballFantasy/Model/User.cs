﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

        public User(string Password, string name, string email, string username)
        {
            this.name = name;
            this.email = email;
            userName = username;
            password = password;
        }

        public static void validationEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"[0-9a-ZA-z]{1}[0-9a-zA-Z\.]{5,29}[0-9a-ZA-z]{1}@{1}[0-9a-zA-Z]+\.[a-zA-z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
        public static void validationName(string name)
        {
            if (name == null)
            {
                throw new Exception("please enter your name");
            }
            Regex regex = new Regex("^(?=.*[a-z])(?=.*\\d).+$");
            if (!Regex.IsMatch(name, "\\d"))
            {
                throw new Exception("No number found.");
            }
            else if (!Regex.IsMatch(name, "[a-z]"))
            {
                throw new Exception("No letter found.");
            }
            if (name.Length >= 30 && name.Length <= 5)
            {
                throw new Exception("your name length must be in range 5 to 30");
            }
        }
    }
}
