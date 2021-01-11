using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.DatabaseAccess.sources.customersSourceModel
{
    public interface ICustomersSourceModel
    {
        List<Customer> GetCustomers();
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
    }
}
