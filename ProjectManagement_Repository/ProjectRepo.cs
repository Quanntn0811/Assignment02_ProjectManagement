using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_BusinessObjects.Enums;
using ProjectManagement_DAO;
using ProjectManagement_Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly ProjectDAO projectDAO = null;

        public ProjectRepo()
        {
            projectDAO = new ProjectDAO();
        }

        public IEnumerable<Project> GetProjects() => projectDAO.GetProjects();
        public Project GetProject(int id) => projectDAO.GetProject(id);

        public IEnumerable<ProjectStatus> GetProjectStatus() => projectDAO.GetProjectStatus();     

        public void AddNew(CreateNewProjectRequest project) => projectDAO.AddNew(project);

        public void Delete(int id) => projectDAO.Delete(id);
        public void Update(int id, UpdateProjectRequest updateProjectRequest) => projectDAO.Update(id, updateProjectRequest);
        public IEnumerable<Project> GetSearchProjects(string name, string customer, string number, string status) => projectDAO.GetSearchProjects(name, customer, number, status);
    }
}
