using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Service.interfaces
{
    public interface IUserService
    {
        public User Login(string email, string password);
    }
}
