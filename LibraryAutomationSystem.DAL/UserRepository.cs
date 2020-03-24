﻿using LibraryAutomationSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAutomationSystem.DAL
{
    public class UserRepository
    {
        public int AddUser(User user)//Add User by User Entity
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                dbConnection.Users.Add(user);
               return dbConnection.SaveChanges();//return the save changed rows as a integer
            }

        }
        public IEnumerable<User> GetUser()//Get the User as list
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.Users.ToList();//Convert the table to list and return it
            }
        }
        public User CheckUser(User user)
        {
            using (DBConnection dbConnection = new DBConnection())
            {

                User checkUser = dbConnection.Users.Where(u => u.MemberUserName == user.MemberUserName && u.MemberPassword == user.MemberPassword).FirstOrDefault();//Check the username and password and return the entity by using first or default
                return checkUser;//return the logined user
            }

        }
        public User FindUserById(int userId)//Find user by ID
        {
            using (DBConnection dbConnection = new DBConnection())
            {
               
                return dbConnection.Users.Find(userId);//return the user where the userid is match
            }
        }
        public int DeleteUser(int userId)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                User user = FindUserById(userId);//Find the user by Userid
                dbConnection.Entry(user).State = System.Data.Entity.EntityState.Deleted;//Delete the User by entity state
                return dbConnection.SaveChanges();////return the affected rows
            }

            }
    }
}
