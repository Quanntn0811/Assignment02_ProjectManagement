using System;
using System.Collections.Generic;

namespace ProjectManagement_BusinessObjects.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;
    }
}
