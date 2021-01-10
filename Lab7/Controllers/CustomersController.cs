using Lab7.DatabaseAccess;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private CompanyManagementContext context;

        public CustomersController(CompanyManagementContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            return Ok(context.Customers.ToList().Select(c => ToViewModel(c)));
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerViewModel customer)
        {
            var newCustomer = ToCustomerModel(customer);

            context.Customers.Add(newCustomer);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCustomer(CustomerViewModel customer)
        {
            var customerToUpdate = context.Customers.ToList().FirstOrDefault(c => c.CustId == customer.Id);
            if (customerToUpdate == null) return NotFound();

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Email= customer.Email;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;

            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            var customertoDelete = context.Customers.ToList().FirstOrDefault(c => c.CustId == id);
            if (customertoDelete == null) return NotFound();

            context.Customers.Remove(customertoDelete);

            return Ok();
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
