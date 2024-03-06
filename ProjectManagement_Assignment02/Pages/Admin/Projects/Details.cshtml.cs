using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Admin.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly IProjectService _projectService;

        public DetailsModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

      public Project Project { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetProject(id);

            if (project == null)
            {
                return NotFound();
            }
            else
            {
                Project = project;
            }
            return Page();
        }
    }
}
