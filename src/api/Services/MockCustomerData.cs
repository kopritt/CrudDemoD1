using RestApiCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCrudDemo.CustomerData
{
    public class MockCustomerData : ICustomerData
    {
        private List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Mateus"
            },
            new Customer()
            {
                Id = Guid.NewGuid(),
                Name = "Fabio"
            }
        };

        public Customer AddCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            customers.Add(customer);
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        public Customer EditCustomer(Customer customer)
        {
            var existingCustomer = GetCustomer(customer.Id);
            existingCustomer.Name = customer.Name;
            existingCustomer.BirthDate = customer.BirthDate;
            existingCustomer.Telephone = customer.Telephone;
            existingCustomer.Cpf = customer.Cpf;
            existingCustomer.Rg = customer.Rg;
            return existingCustomer;
        }

        public Customer GetCustomer(Guid id)
        {
            return customers.SingleOrDefault(x => x.Id == id);
        }

        public Customer GetCustomerByName(string name)
        {
            return customers.SingleOrDefault(x => x.Name == name);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public List<Customer> GetCustomers(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
