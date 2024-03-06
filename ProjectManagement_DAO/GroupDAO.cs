using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DAO
{
    public class GroupDAO
    {
        private readonly ProjectManagementContext _context = null;
        private static GroupDAO _instance = null;

        public static GroupDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GroupDAO();
                }

                return _instance;
            }
        }

        public GroupDAO()
        {
            _context = new ProjectManagementContext();
        }

        public IEnumerable<Group> GetGroups()
        {
            return _context.Groups.Include(g => g.GroupLeader).ToList();
        }

        public Group GetGroup(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)         
                throw new Exception($"The group with ID {id} does not exists");
            

            return group;
        }

        public void AddNew(Group group)
        {
            Group gr = new()
            {
                GroupLeaderId = group.GroupLeaderId
            };

            _context.Groups.Add(gr);
            _context.SaveChanges();
        }
        public void Update(int id, Group group)
        {
            Group gr = _context.Groups.FirstOrDefault(x => x.Id == id);

            gr.GroupLeaderId = group.GroupLeaderId;

            _context.Groups.Update(gr);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entity = ex.Entries.Single();
                var databaseValues = entity.GetDatabaseValues();

                entity.OriginalValues.SetValues(databaseValues);
                throw new Exception("The record you attempt to update was modified by another user after you got the orginal values");
            }

        }
        public void Delete(int id)
        {
            var gr = _context.Groups.FirstOrDefault(x => x.Id == id);

            if (gr == null)
                throw new Exception($"The Group witd ID {id} does not exist.");

            _context.Groups.Remove(gr);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Don't know how to handle concurrency conflicts");
            }
        }
    }
}
