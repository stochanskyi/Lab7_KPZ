using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class Project
    {
        public Project()
        {
            Boards = new HashSet<Board>();
            ProjectPhases = new HashSet<ProjectPhase>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal? Budget { get; set; }
        public int CustId { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ProjectStatus Status { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<ProjectPhase> ProjectPhases { get; set; }
    }
}
