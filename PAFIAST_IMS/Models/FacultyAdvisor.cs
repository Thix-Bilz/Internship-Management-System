using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAFIAST_IMS.Models
{
    public class FacultyAdvisor
    {
        [Key]
        public int FAId { get; set; }
        [Required]
        [DisplayName("Faculty Advisor’s Name")]
        public string? FacultyAdvisorName { get; set; }
        [DisplayName("Department")]
        public string? FacultyAdvisorDept { get; set; }
        [DisplayName("Designation")]
        public string? FacultyAdvisorDesignation { get; set; }
        [DisplayName("Contact No(s)")]
        public string? FacultyAdvisorContactNo { get; set; }
        [DisplayName("E-mail Address")]
        public string? FacultyAdvisorEmail { get; set; }
        [DisplayName("Date")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public int stdinfoid { get; set; }
        public virtual stdInfo stdinfo { get; set; }


    }
}
