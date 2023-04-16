using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MTrackerWebAPI.Model
{
    public class ManagerComments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerCommentID { get; set; }
        public string? Comments { get; set; }
        public int? ProjectTaskID { get; set; }
    }
}
