using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
