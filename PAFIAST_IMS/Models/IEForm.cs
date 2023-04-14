

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAFIAST_IMS.Models
{
    public class IEForm
    {   
        [Key]
        public int IEFId { get; set; }
        [Required]

/*        [DisplayName("Organization/Industry Name and City")]
        public string? INC { get; set; }
        [DisplayName("Industry Supervisor’s Name")]
        public string? ISName { get; set; }
        public string? ISDesignation { get; set; }
        [DisplayName("Starting Date of Internship")]
        public DateTime JD { get; set; }
        [DisplayName("Ending Date of Internship")]
        public DateTime SD { get; set; }*/

        [DisplayName("Has student maintained his diary/notes every day")]
        public string? P2 { get; set; }
        [DisplayName("Attendance of the student")]
        public string? P3 { get; set; }
        [DisplayName("Professional attitude of the student")]
        public string? P4 { get; set; }
        [DisplayName("5.	Performance as an individual and teamwork")]
        public string? P5 { get; set; }
        [DisplayName("6.	Internship report and presentation submitted to industry supervisor (Signed and stamped soft and hard copy)")]
        public string? P6 { get; set; }
        [DisplayName("Comment")]
        public string? Comment  { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int stdinfoid { get; set; }
        public virtual stdInfo stdinfo { get; set; }
    }
}
