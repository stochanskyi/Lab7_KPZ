using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class BoardTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int ColumnId { get; set; }
        public int? PhaseId { get; set; }
        public DateTime? DueDate { get; set; }
        public int? AssignedId { get; set; }

        public virtual Worker Assigned { get; set; }
        public virtual BordColum Column { get; set; }
        public virtual ProjectPhase Phase { get; set; }
    }
}
