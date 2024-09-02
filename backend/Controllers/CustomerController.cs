using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            var updatedCustomer = _customerService.UpdateCustomer(customer);
            if (updatedCustomer == null) return NotFound();
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var success = _customerService.DeleteCustomer(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

