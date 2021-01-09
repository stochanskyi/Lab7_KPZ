using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class AccessLevel
    {
        public AccessLevel()
        {
            Workers = new HashSet<Worker>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
