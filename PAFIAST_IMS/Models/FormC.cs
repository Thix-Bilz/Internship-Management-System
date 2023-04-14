using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAFIAST_IMS.Models
{
    public class FormC
    {
        [Key]
        public int FormCId { get; set; }
        [Required]
        [PersonalData]
        public string? I_Semester { get; set; } // I_Semester = Internship Semester
        public string? IE_Name { get; set; } // IE_Name = Internship Employer Name
        public string? I_Dept { get; set; } // I_Dept = Internship Department
        public DateTime Joining_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        /*        [ForeignKey("stdInfo")]
                public int stdInfoid { get; set; }
                public stdInfo? stdInfo { get; set; }*/

        public int stdinfoid { get; set; }
        public virtual stdInfo stdinfo { get; set; }

/*        public string hosteliteId { get; set; }
        public virtual HosteliteData HosteliteData { get; set; }*/
    }
}
