using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class Worker
    {
        public Worker()
        {
            BoardTasks = new HashSet<BoardTask>();
            WorkerPaymentConfirmers = new HashSet<WorkerPayment>();
            WorkerPaymentReceivers = new HashSet<WorkerPayment>();
        }

        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PositionId { get; set; }
        public string Email { get; set; }
        public int? LevelId { get; set; }

        public virtual AccessLevel Level { get; set; }
        public virtual Position Position { get; set; }
        public virtual WorkerSelary WorkerSelary { get; set; }
        public virtual ICollection<BoardTask> BoardTasks { get; set; }
        public virtual ICollection<WorkerPayment> WorkerPaymentConfirmers { get; set; }
        public virtual ICollection<WorkerPayment> WorkerPaymentReceivers { get; set; }
    }
}
