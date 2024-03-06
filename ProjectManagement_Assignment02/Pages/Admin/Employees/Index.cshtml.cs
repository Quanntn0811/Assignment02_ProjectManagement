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

namespace ProjectManagement_Assignment02.Pages.Admin.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _service;

        public IndexModel(IEmployeeService service)
        {
            _service = service;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (_service.GetEmployees() != null)
            {
                Employee = _service.GetEmployees().ToList();    
            }

            return Page();
        }
    }
}
