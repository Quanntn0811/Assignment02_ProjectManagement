using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DAO
{
    public class UserDAO
    {
        private readonly ProjectManagementContext _context = null;
        private static UserDAO _instance = null;

        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }

                return _instance;
            }
        }

        public UserDAO()
        {
            _context = new ProjectManagementContext();
        }

        public User Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            
            if (user == null)
            {
                throw new Exception("Wrong email or password!");
            }

            return user;
        }

    }
}
