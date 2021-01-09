using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class WorkerPayment
    {
        public int PaymentId { get; set; }
        public int ReceiverId { get; set; }
        public int ConfirmerId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? PaymentStatusId { get; set; }

        public virtual Worker Confirmer { get; set; }
        public virtual WorkerPaymentStatus PaymentStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Worker Receiver { get; set; }
    }
}
