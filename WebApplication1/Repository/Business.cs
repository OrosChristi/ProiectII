using DataProject;
using DataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Business
    {

        private DataBaseContext _dbContext;
        public DataBaseContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DataBaseContext();
                }

                return _dbContext;
            }
        }

        private UsersRepo _userRepo;
        public UsersRepo UserRepo 
        { 
            get 
            {
                if (_userRepo == null) {
                    _userRepo = new UsersRepo(DbContext);
                }

                return _userRepo;
            } 
        }
        
    }
}
