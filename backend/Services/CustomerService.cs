using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Data;

namespace Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer == null) return null;

            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Email = customer.Email;
            _context.SaveChanges();

            return existingCustomer;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return true;
        }
    }
}

