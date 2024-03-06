using System;
using System.Collections.Generic;

namespace ProjectManagement_BusinessObjects.Entities
{
    public partial class ProjectEmployee
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
