using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class BordColum
    {
        public BordColum()
        {
            BoardTasks = new HashSet<BoardTask>();
        }

        public int ColumnId { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public short? ColumnPosition { get; set; }

        public virtual Board Board { get; set; }
        public virtual ICollection<BoardTask> BoardTasks { get; set; }
    }
}
