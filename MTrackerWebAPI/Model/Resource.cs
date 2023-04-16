using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace MTrackerWebAPI.Model
{
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ResourceID { get; set; }
        public string? ResourceName { get; set; }
        public string? Destination { get; set; }
        public int? ManagerID { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailID { get; set; }
        public string? SkillSets { get; set; }

    }
}

