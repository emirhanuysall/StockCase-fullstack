using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}

