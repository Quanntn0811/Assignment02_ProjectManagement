using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using ProjectManagement_Repository;
using ProjectManagement_Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Service
{
    public class GroupService : IGroupService
    {
        private readonly GroupRepo groupRepo = null;

        public GroupService()
        {
            groupRepo = new GroupRepo();
        }

        public IEnumerable<Group> GetGroups()
        {
            return groupRepo.GetGroups();
        }

        public Group GetGroup(int id) => groupRepo.GetGroup(id);

        public void AddNew(Group group) => groupRepo.AddNew(group);
        public void Update(int id, Group group) => groupRepo.Update(id, group);
        public void Delete(int id) => groupRepo.Delete(id);
    }
}
