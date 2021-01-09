using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class WorkerInTeam
    {
        public int WorkerId { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
