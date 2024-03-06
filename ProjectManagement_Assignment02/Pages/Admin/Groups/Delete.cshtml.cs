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

namespace ProjectManagement_Assignment02.Pages.Admin.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly IGroupService _service;

        public DeleteModel(IGroupService service)
        {
            _service = service;
        }

        [BindProperty]
      public Group Group { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _service.GetGroup(id);

            if (group == null)
            {
                return NotFound();
            }
            else 
            {
                Group = group;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var group = _service.GetGroup(id);

            if (group != null)
            {
                Group = group;
                _service.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
