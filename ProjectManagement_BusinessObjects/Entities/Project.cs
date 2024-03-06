using System;
using System.Collections.Generic;

namespace ProjectManagement_BusinessObjects.Entities
{
    public partial class Project
    {
        public Project()
        {
            ProjectEmployees = new HashSet<ProjectEmployee>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Version { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
