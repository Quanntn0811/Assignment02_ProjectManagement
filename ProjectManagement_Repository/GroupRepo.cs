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
    public class GroupRepo : IGroupRepo
    {
        private readonly GroupDAO groupDAO = null;

        public GroupRepo()
        {
            groupDAO = new GroupDAO();
        }
        public IEnumerable<Group> GetGroups()
        {
            return groupDAO.GetGroups();
        }

        public Group GetGroup(int id) => groupDAO.GetGroup(id);

        public void AddNew(Group group) => groupDAO.AddNew(group);
        public void Update(int id, Group group) => groupDAO.Update(id, group);
        public void Delete(int id) => groupDAO.Delete(id);
    }
}
