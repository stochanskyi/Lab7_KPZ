using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
