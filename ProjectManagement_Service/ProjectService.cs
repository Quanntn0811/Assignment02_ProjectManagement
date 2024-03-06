using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_BusinessObjects.Enums;
using ProjectManagement_DAO;
using ProjectManagement_Repository;
using ProjectManagement_Repository.interfaces;
using ProjectManagement_Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo projectRepo = null;

        public ProjectService()
        {
            projectRepo = new ProjectRepo();
        }

        public IEnumerable<Project> GetProjects()
        {
            return projectRepo.GetProjects();
        }

        public Project GetProject(int id) => projectRepo.GetProject(id);

        public IEnumerable<ProjectStatus> GetProjectStatus()
        {
            return projectRepo.GetProjectStatus();
        }

        public void AddNew(CreateNewProjectRequest project)
        {
           projectRepo.AddNew(project);
        }

        public void Delete(int id) => projectRepo.Delete(id);

        public void Update(int id, UpdateProjectRequest updateProjectRequest) => projectRepo.Update(id, updateProjectRequest);
        public IEnumerable<Project> GetSearchProjects(string name, string customer, string number, string status) => projectRepo.GetSearchProjects(name, customer, number, status);
    }
}
