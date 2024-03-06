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
using ProjectManagement_DAO;
using ProjectManagement_Service;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Admin.Projects
{
    public class EditModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IGroupService _groupService;
        private readonly IEmployeeService _employeeService;

        public EditModel(IProjectService projectService, IGroupService groupService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _groupService = groupService;
            _employeeService = employeeService;
        }

        [BindProperty]
        public UpdateProjectRequest UpdateProjectRequest { get; set; } = default!;
        public List<SelectListItem> ListGroupId { get; set; }
        public List<SelectListItem> Status { get; set; }
        public List<SelectListItem> listMember { get; set; }

        public IActionResult OnGet(int id)
        {
            ListInitial();

            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetProject(id);

            if (project == null)
            {
                return NotFound();
            }

            UpdateProjectRequest = new UpdateProjectRequest
            {
                Id = id,
                Name = project.Name,
                Customer = project.Customer,
                GroupId = project.GroupId,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["Message"] = "";


            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UpdateProjectRequest.StartDate > UpdateProjectRequest.EndDate)
            {
                ListInitial();
                ViewData["Message"] = "Start Date must come before End Date";
                return Page();
            }

            try
            {
                _projectService.Update(UpdateProjectRequest.Id, UpdateProjectRequest);
            }
            catch (Exception ex)
            {
                ListInitial();

                ViewData["NumberMessage"] = ex.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private void ListInitial()
        {
            ListGroupId = _groupService.GetGroups().Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Id.ToString(),
            }).ToList();

            Status = _projectService.GetProjectStatus().Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s.ToString(),
            }).ToList();

            listMember = _employeeService.GetEmployees().Select(e => new SelectListItem
            {
                Value = e.Visa,
                Text = e.Visa + ": " + e.FirstName + " " + e.LastName,
            }).ToList();
        }
    }
}
