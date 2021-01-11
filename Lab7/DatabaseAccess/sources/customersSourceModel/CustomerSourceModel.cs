using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.DatabaseAccess.sources.customersSourceModel
{
    public class CustomerSourceModel : ICustomersSourceModel
    {

        private CompanyManagementContext context;

        public CustomerSourceModel(CompanyManagementContext context)
        {
            this.context = context;
        }

        public void DeleteCustomer(int id)
        {
            var customerToDelete = context.Customers.ToList().FirstOrDefault(c => c.CustId == id);
            if (customerToDelete == null) throw new Exception();
            
            context.Customers.Remove(customerToDelete);

            context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerToUpdate = context.Customers.ToList().FirstOrDefault(c => c.CustId == customer.CustId);
            if (customerToUpdate == null) throw new Exception();

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;

            context.SaveChanges();
        }
    }
}
