using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Service;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Admin.Projects
{
    public class IndexModel : PageModel
    {
        private readonly IProjectService _service;

        public IndexModel(IProjectService service)
        {
            _service = service;
        }

        public IList<Project> Project { get;set; } = default!;
        public List<SelectListItem> Status { get; set; }

        public IActionResult OnGet(string name, string customer, string number)
        {
            Status = _service.GetProjectStatus().Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s.ToString(),
            }).ToList();

            Project = _service.GetProjects().ToList();

            if (name != null || customer != null)
            {
                Project = _service.GetSearchProjects(name, customer, number, "").ToList();

            }

            return Page();
        }

        public IActionResult OnGetSearch(string name, string customer, string number)
        {
            Status = _service.GetProjectStatus().Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s.ToString(),
            }).ToList();

            Project = _service.GetProjects().ToList();

            if (name != null || customer != null)
            {
                Project = _service.GetSearchProjects(name, customer, number, "").ToList();

            }

            return Page();
        }
    }
}
