using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTrackerWebAPI.Model.ViewModel
{
    public class ProjectTaskDetailsViewModel
    {
        public ProjectTaskDetailsViewModel()
        {

        }
        public int ProjectTaskID { get; set; }
        public string? ResourceName { get; set; }
        public string? ProjectName { get; set; }
        public string? Story { get; set; }

    }
}
