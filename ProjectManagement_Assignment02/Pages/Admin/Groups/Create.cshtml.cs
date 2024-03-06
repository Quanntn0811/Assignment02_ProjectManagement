using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Admin.Groups
{
    public class CreateModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IEmployeeService _employeeService;

        public CreateModel(IGroupService groupService, IEmployeeService employeeService)
        {
            _groupService = groupService;
            _employeeService = employeeService;
        }

        public List<SelectListItem> GroupLeaders { get; set; }

        public IActionResult OnGet()
        {
            GroupLeaders = _employeeService.GetEmployees().Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.Visa}: {e.FirstName} {e.LastName}"
            }).ToList();

            return Page();
        }

        [BindProperty]
        public Group Group { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _groupService.AddNew(Group);

            return RedirectToPage("./Index");
        }
    }
}
