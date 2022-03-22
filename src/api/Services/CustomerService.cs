using MongoDB.Driver;
using RestApiCrudDemo.Interfaces;
using RestApiCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCrudDemo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<CustomerModel> _customer;

        public CustomerService()
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            var database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));

            _customer = database.GetCollection<CustomerModel>(Environment.GetEnvironmentVariable("COLLECTION_NAME"));
        }

        public async Task<CustomerModel> AddCustomer(CustomerModel customer)
        {
            await _customer.InsertOneAsync(customer);
            return customer;
        }

        public async Task DeleteCustomer(CustomerModel customer)
        {
            var response = await _customer.DeleteOneAsync(x => x.Cpf == customer.Cpf);
        }

        public async Task<CustomerModel> EditCustomer(List<CustomerModel> customerDefault, string cpf)
        {
            var customer = customerDefault.FirstOrDefault(x => x.Cpf == cpf);


            if (customer == null)
            {
                return null;
            }
            await _customer.ReplaceOneAsync(x => x.Cpf == customer.Cpf, customer);
            return customer;
        }

        public CustomerModel GetCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerModel>> GetCustomerByName(string name)
        {
            var reponse = await _customer.FindAsync(x => x.CustomerName == name);
            return reponse.ToList();
        }

        public  async Task<List<CustomerModel>> GetCustomers()
        {
            var response = await _customer.FindAsync<CustomerModel>(x => true);

            return response.ToList();
        }
    }
}
