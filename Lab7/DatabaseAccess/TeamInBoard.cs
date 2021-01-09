using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class TeamInBoard
    {
        public int TeamId { get; set; }
        public int BoardId { get; set; }

        public virtual Board Board { get; set; }
        public virtual Team Team { get; set; }
    }
}
