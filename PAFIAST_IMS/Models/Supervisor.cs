using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAFIAST_IMS.Models
{
    public class Supervisor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Industry Supervisor’s Name")]
        public string? SupervisorName { get; set; }
        [DisplayName("Organization/Industry Name and City")]
        public string? SupervisorIN { get; set; }
        [DisplayName("Designation")]
        public string? SupervisorDesignation { get; set; }
        [DisplayName("Contact No(s)")]
        public string? SupervisorContactNo { get; set; }
        [DisplayName("E-mail Address")]
        public string? SupervisorEmail { get; set; }
        [DisplayName("Date")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public int stdinfoid { get; set; }
        public virtual stdInfo stdinfo { get; set; }


    }
}
