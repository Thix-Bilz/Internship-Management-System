using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PAFIAST_IMS.Models
{
    public class AssignTask
    {
        [Key]
        public int ATId { get; set; }
        [Required]
        [DisplayName("Tasks")]
        public string? Tasks { get; set; }
        [DisplayName("Evaluation")]
        public string? Evaluation { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int stdinfoid { get; set; }
        public virtual stdInfo stdinfo { get; set; }
    }
}
