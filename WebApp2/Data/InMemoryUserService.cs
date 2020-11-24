using System;
using System.Collections.Generic;
using System.Linq;
using WebApp2.DataAccess;
using WebApp2.Models;

namespace WebApp2.Data
{
    public class InMemoryUserService : IUserService
    {
        User user;
        private FamilyDBContext ctx;
        private List<User> users;
        public InMemoryUserService(FamilyDBContext ctx)
        {
            this.ctx = ctx;
            //Roles:
            //"User" = Can controll own ToDos 
            //"Admin" = Can controll all ToDos

            //SecurityLevel:
            //1 = Can view ToDos determined by Role
            //2 = Cam view, create and delete ToDos determined by Role
        }


        public User ValidateUser(string userName, string password)
        {
            User first = ctx.Users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            user = first;
            return first;
        }
    }
}
