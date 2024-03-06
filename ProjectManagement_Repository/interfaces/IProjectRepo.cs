using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_BusinessObjects.Enums;
using ProjectManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository.interfaces
{
    public interface IProjectRepo
    {
        public IEnumerable<Project> GetProjects();
        public Project GetProject(int id);
        public IEnumerable<ProjectStatus> GetProjectStatus();
        public void AddNew(CreateNewProjectRequest project);
        public void Delete(int id);
        public void Update(int id, UpdateProjectRequest updateProjectRequest);
        public IEnumerable<Project> GetSearchProjects(string name, string customer, string number, string status);
    }
}
