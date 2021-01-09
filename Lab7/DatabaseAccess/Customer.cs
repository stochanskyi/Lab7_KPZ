using System;
using System.Collections.Generic;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerPayments = new HashSet<CustomerPayment>();
            Projects = new HashSet<Project>();
        }

        public int CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
