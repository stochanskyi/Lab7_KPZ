using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class ProjectPhase
    {
        public ProjectPhase()
        {
            BoardTasks = new HashSet<BoardTask>();
        }

        public int PhaseId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<BoardTask> BoardTasks { get; set; }
    }
}
