using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class WorkerSelary
    {
        public int WorkerId { get; set; }
        public decimal Selary { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
