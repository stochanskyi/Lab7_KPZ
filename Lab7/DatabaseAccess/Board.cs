using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class Board
    {
        public Board()
        {
            BordColums = new HashSet<BordColum>();
        }

        public int BoardId { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<BordColum> BordColums { get; set; }
    }
}
