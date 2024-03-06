using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Admin.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _service;

        public EditModel(IEmployeeService service)
        {
            _service = service;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            Employee = employee;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _service.Update(Employee.Id, Employee);
            }
            catch (Exception ex)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
