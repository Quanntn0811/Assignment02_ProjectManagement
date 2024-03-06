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
    public class DeleteModel : PageModel
    {
        private readonly IProjectService _service;

        public DeleteModel(IProjectService service)
        {
            _service = service;
        }

        [BindProperty]
        public Project Project { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _service.GetProject(id);

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

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = _service.GetProject(id);

            if (project != null)
            {
                _service.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
