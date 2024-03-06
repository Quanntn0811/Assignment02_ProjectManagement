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
    public class IndexModel : PageModel
    {
        private readonly IGroupService _service;

        public IndexModel(IGroupService service)
        {
            _service = service;
        }

        public IList<Group> Group { get;set; } = default!;

        public IActionResult OnGet()
        {
            Group = _service.GetGroups().ToList(); 

            return Page();
        }
    }
}
