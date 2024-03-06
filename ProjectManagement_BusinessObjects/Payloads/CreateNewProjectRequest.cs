using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DAO
{
    public class CreateNewProjectRequest
    {
        [Required]
        [DisplayName("Group Id")]
        public int GroupId { get; set; }
        [Required]
        [DisplayName("Project Number")]
        public int Number { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Project's name must be no longer than 50 characters")]
        [DisplayName("Project Name")]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(50, ErrorMessage = "Project's customer must be no longer than 50 characters")]
        public string Customer { get; set; } = null!;
        [Required]
        public string Status { get; set; } = null!;
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Members")]
        public List<string>? Employees { get; set; }
    }
}
