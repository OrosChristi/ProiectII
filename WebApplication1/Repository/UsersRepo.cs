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
        public List<User> GetUser()
        {
            

            return context.Users.ToList();
        }
    }
}
