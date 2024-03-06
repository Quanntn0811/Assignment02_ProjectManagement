using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectManagement_Assignment02.ViewModels;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Service.interfaces;

namespace ProjectManagement_Assignment02.Pages.Authorization
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _service;

        public LoginModel(IUserService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Page();
        }

        [BindProperty]
        public LoginVM User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = _service.Login(User.Email, User.Password);

                if (user.Role == "User")
                {
                    ViewData["ErrorMessage"] = "You are not allow to access the system";

                    return Page();
                }

                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;

                return Page();
            }

            return RedirectToPage("/Admin/Projects/Index");
        }
    }
}
