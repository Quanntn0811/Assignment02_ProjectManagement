using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using ProjectManagement_Repository.interfaces;
using ProjectManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo = null;

        public UserService()
        {
            _userRepo = new UserRepo();
        }
        public User Login(string email, string password) => _userRepo.Login(email, password);
    }
}
