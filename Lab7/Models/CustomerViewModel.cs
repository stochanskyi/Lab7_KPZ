using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class CustomerViewModel
    {

        public CustomerViewModel() { }

        public CustomerViewModel(int Id, string FirstName, string LastName, string Country, string Email, string PhoneNumber)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Country = Country;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
