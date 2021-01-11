using Lab7.DatabaseAccess;
using Lab7.DatabaseAccess.sources.customersSourceModel;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.repositories.customers
{
    public class CustomersRepository : ICustomersRepository
    {

        private ICustomersSourceModel sourceModel;

        public CustomersRepository(ICustomersSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        public void AddCustomer(CustomerViewModel customer)
        {
            sourceModel.InsertCustomer(ToCustomerModel(customer));
        }

        public void DeleteCustomer(int id)
        {
            sourceModel.DeleteCustomer(id);
        }

        public List<CustomerViewModel> GetCustomers()
        {
            return sourceModel.GetCustomers().ToList().Select(c => ToViewModel(c)).ToList();
        }

        public void UpdateCustomer(CustomerViewModel customer)
        {
            sourceModel.UpdateCustomer(ToCustomerModel(customer));
        }

        private CustomerViewModel ToViewModel(Customer customer)
        {
            return new CustomerViewModel(
                customer.CustId,
                customer.FirstName,
                customer.LastName,
                customer.Country,
                customer.Email,
                customer.PhoneNumber
                );
        }

        private Customer ToCustomerModel(CustomerViewModel customer)
        {
            return new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Country = customer.Country,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }
}
