using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            WorkerPayments = new HashSet<WorkerPayment>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkerPayment> WorkerPayments { get; set; }
    }
}
