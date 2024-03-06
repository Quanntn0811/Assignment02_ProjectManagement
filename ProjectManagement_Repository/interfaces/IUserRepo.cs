using ProjectManagement_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository.interfaces
{
    public interface IUserRepo
    {
        public User Login(string email, string password);
    }
}
