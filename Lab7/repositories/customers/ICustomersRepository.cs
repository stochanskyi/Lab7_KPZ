using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.repositories.customers
{
    public interface ICustomersRepository
    {
        List<CustomerViewModel> GetCustomers();
        void AddCustomer(CustomerViewModel customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(CustomerViewModel customer);
    }
}
