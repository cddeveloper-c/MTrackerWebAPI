using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MTrackerWebAPI.Model
{
    public class ProjectTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectTaskID { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int? TaskCompletion { get; set; }
        public int UserStoryID { get; set; }    
    }
}
