using RestApiCrudDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiCrudDemo.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomers();

        Task<List<CustomerModel>> GetCustomerByName(string name);

        CustomerModel GetCustomer(string id);

        Task<CustomerModel> AddCustomer(CustomerModel customer);

        Task DeleteCustomer(CustomerModel customer);

        Task<CustomerModel> EditCustomer(List<CustomerModel> customerDefault, string cpf);
    }
}
