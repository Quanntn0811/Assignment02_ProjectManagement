using System;
using System.Collections.Generic;

namespace ProjectManagement_BusinessObjects.Entities
{
    public partial class Group
    {
        public Group()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public int GroupLeaderId { get; set; }
        public int Version { get; set; }

        public virtual Employee GroupLeader { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; }
    }
}
