using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class WorkerPaymentStatus
    {
        public WorkerPaymentStatus()
        {
            WorkerPayments = new HashSet<WorkerPayment>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkerPayment> WorkerPayments { get; set; }
    }
}
