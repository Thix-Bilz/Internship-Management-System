using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAFIAST_IMS.Models
{
    public class stdInfo
    {
        //public stdInfo()    {   Form_C = new List<FormC>();   }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stdId { get; set; } 
        [Required]
        public string? stdName { get; set; }
        public string? stdFatherName { get; set; }
        public string? stdReg_no { get; set; }
        public string? stdDept { get; set; }
        public string? stdCNIC { get; set; }
        public string? stdContact_no { get; set; }
        public string? stdAddress { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string userid { get; set; }
        //public virtual IdentityUser? User { get; set; }
        //Navigation Properties
        //public virtual List<FormC> Form_C { get; set; }
        public virtual FormC FormCs { get; set; }
        public virtual Supervisor Supervisors { get; set; }
        public virtual IEForm IEForms { get; set; }
        public virtual List<AssignTask> AssignTasks { get; set; }
        public virtual List<FacultyAdvisor> FacultyAdvisors { get; set; }
        //public virtual List<ImageModel> ImageModels { get; set; }
    }
}
