using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class CustomerPayment
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
        public int? ProjectId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
