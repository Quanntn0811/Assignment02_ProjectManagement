using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using ProjectManagement_Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDAO _userDAO = null;

        public UserRepo()
        {
            _userDAO = new UserDAO();
        }
        public User Login(string email, string password) => _userDAO.Login(email, password);
    }
}
