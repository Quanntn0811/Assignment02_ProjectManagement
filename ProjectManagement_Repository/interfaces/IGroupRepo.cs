using ProjectManagement_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository.interfaces
{
    public interface IGroupRepo
    {
        public IEnumerable<Group> GetGroups();
        public Group GetGroup(int id);
        public void AddNew(Group group);
        public void Update(int id, Group group);
        public void Delete(int id);
    }
}
