using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MTrackerWebAPI.Model
{
    public class UserStories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserStoryID { get; set; }
        public String? Story { get; set; }
        public int ProjectID { get; set; }
    }
}
