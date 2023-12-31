﻿using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class UserHandel
    {
        public static void pointCalculate(User user)
        {
            user.weeklyPoint = 0;
            var pl = new Player();
            foreach (var player in user.insideDEF)
            {
                pl = PlayerHandle.findPlayerByCode(player);
                if (pl != null)
                {
                    user.weeklyPoint += 2 * (pl.event_points);
                }
            }

            foreach (var player in user.insideMID)
            {
                pl = PlayerHandle.findPlayerByCode(player);
                if (pl != null)
                {
                    user.weeklyPoint += 2 * (pl.event_points);
                }
            }

            foreach (var player in user.insideFRW)
            {
                pl = PlayerHandle.findPlayerByCode(player);
                if (pl != null)
                {
                    user.weeklyPoint += 2 * (pl.event_points);
                }
            }

            pl = PlayerHandle.findPlayerByCode(user.insideGK);
            if (pl != null)
            {
                user.weeklyPoint += 2 * (pl.event_points);
            }

            pl = PlayerHandle.findPlayerByCode(user.outsideGK);
            if (pl != null)
            {
                user.weeklyPoint += 2 * (pl.event_points);
            }

            pl = PlayerHandle.findPlayerByCode(user.outsideDEF);
            if (pl != null)
            {
                user.weeklyPoint += 2 * (pl.event_points);
            }

            pl = PlayerHandle.findPlayerByCode(user.outsideMID);
            if (pl != null)
            {
                user.weeklyPoint += 2 * (pl.event_points);
            }

            pl = PlayerHandle.findPlayerByCode(user.outsideFRW);
            if (pl != null)
            {
                user.weeklyPoint += 2 * (pl.event_points);
            }

            user.totalPoint += user.weeklyPoint;
            handelUserDatabase.saveChanges(user);
        }

        public static void addMoneyToWallet(int code, User user)
        {
            Player player = PlayerHandle.findPlayerByCode(code);
            user.budget += player.now_cost;
            handelUserDatabase.saveChanges(user);
        }
        public static void deleteMoneyToWallet(int code, User user)
        {
            Player player = PlayerHandle.findPlayerByCode(code);
            user.budget -= player.now_cost;
            handelUserDatabase.saveChanges(user);
        }

        public static void findUserByEmailAndUserName(string email, string userName)
        {
            if (handelUserDatabase.findUserByEmailAndUserName(email, userName) == null)
            {
                throw new Exception("your email or user name is incorrect!");
            }
        }

        public static void sameUserCheck(string email, string username)
        {
            if (DataAccessLayer.handelUserDatabase.isSameEmailUserFind(email))
            {
                throw new Exception("your email is already exist");
            }

            if (DataAccessLayer.handelUserDatabase.isSameUserNameUserFind(username))
            {
                throw new Exception("your user name is already exist");
            }
        }

        public static void sameWaitUserCheck(string email, string username)
        {
            if (DataAccessLayer.handelUserDatabase.isSameEmailWaitUserFind(email))
            {
                throw new Exception("your email is already exist");
            }

            if (DataAccessLayer.handelUserDatabase.isSameUserNameWaitUserFind(username))
            {
                throw new Exception("your user name is already exist");
            }
        }

        public static string login(string userInformation, string password)
        {
            User user;
            if (userInformation.Contains("@"))
            {
                //find email
                user = handelUserDatabase.findUserByemail(userInformation);
                if (user == null)
                {
                    throw new Exception("your email not found!");
                }

                if (user.password != password)
                {
                    throw new Exception("your password is not correct!");
                }
            }
            else
            {
                //find user name
                user = handelUserDatabase.findUserByUserName(userInformation);
                if (user == null)
                {
                    throw new Exception("your user name not found!");
                }

                if (user.password != password)
                {
                    throw new Exception("your password is not correct!");
                }
            }

            string token = tokenHandel.Get_Token(user.userName);
            return token;
        }

        public static void makeNewWaitUser(string password, string name, string email, string username, string code)
        {
            waitingUsers newWaitUser = new waitingUsers(password, DateTime.Now, name, email, username, code);
            handelUserDatabase.addToWaitList(newWaitUser);
        }

        public static void addUser(waitingUsers waitUser, string email)
        {
            //add to user class
            User newUser = new User(waitUser.password, waitUser.name, waitUser.email, waitUser.userName);
            handelUserDatabase.addToUsers(newUser);
            //remove from wait list
            handelUserDatabase.removeFromWaitList(email);
        }

        public static void changeUserPassword(string password, string email)
        {
            //changing user password
            handelUserDatabase.changingPassword(email, password);
            //remove from wait list
            handelUserDatabase.removeFromWaitList(email);
        }

        public static waitingUsers OTPCheck(string otp, string email)
        {
            var waitUser = handelUserDatabase.findWaitUser(otp, email);
            if (waitUser == null)
            {
                handelExpireOTPDatabase.checkAllOTPForExpire();
                throw new Exception("your OTP is incorrect");
            }

            if (expireOTP.checkExpire(waitUser))
            {
                handelExpireOTPDatabase.checkAllOTPForExpire();
                throw new Exception("your OTP is expired");
            }

            return waitUser;
        }

        public static User? GetUserByToken(string token)
        {
            string userName = tokenHandel.decoding_Token(token);
            return handelUserDatabase.findUserByUserName(userName);
        }

        public static List<object> getAllPlayers(User user)
        {
            List<object> result = new List<object>();
            List<Player> players = BuisnessLayer.Team.getAllPlayer(user);
            foreach (var player in players)
            {
                result.Add(player);
            }

            return result;
        }

        public static void calculateAllUsersPoint()
        {
            var allUsers = DataAccessLayer.handelUserDatabase.getUserList();
            foreach (var user in allUsers)
            {
                pointCalculate(user);
            }
        }

        public static List<User> pointTable()
        {
            var users = DataAccessLayer.handelUserDatabase.getUserList();
            for (int i = 0; i < users.Count - 1; i++)
            {
                for (int j = i + 1; j < users.Count; j++)
                {
                    if (users[i].weeklyPoint < users[j].weeklyPoint)
                    {
                        (users[i], users[j]) = (users[j], users[i]);
                    }
                }
            }
            return users;
        }
    }
}