using DataProject;
using DataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsersRepo
    {
        public DataBaseContext context;
        public UsersRepo(DataBaseContext context)
        {
            this.context = context;
        }
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }
        
        public bool Create(User user) 
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(User user)
        {
            if (user != null)
            {
                context.Users.Add(user);
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            //var select = context.Users.Select(Username => user.Username);
            //var result = context.Users.SingleOrDefault(b => b.LastLoginDate == user.LastLoginDate);
            //context.SaveChanges();
        }
    }
}
