using Lab7.DatabaseAccess;
using Lab7.Models;
using Lab7.repositories.customers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private ICustomersRepository repository;

        public CustomersController(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            return Ok(repository.GetCustomers());
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerViewModel customer)
        {
            repository.AddCustomer(customer);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCustomer(CustomerViewModel customer)
        {
            repository.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            repository.DeleteCustomer(id);
            return Ok();
        }
    }
}
