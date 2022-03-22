using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCrudDemo.Services;
using RestApiCrudDemo.Models;
using System;
using RestApiCrudDemo.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCrudDemo.Controllers
{

    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<CustomerModel>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }


        [HttpGet]
        [Route("api/[controller]/{name}")]
        public async Task<List<CustomerModel>> GetCustomerByName(string name)
        {
            return await _customerService.GetCustomerByName(name);
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostCustomer(CustomerModel customer)
        {
            _customerService.AddCustomer(customer);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + customer.Id, customer);

        }

    
        [HttpDelete]
        [Route("api/[controller]/{name}/{cpf}")]
        public async Task<IActionResult> DeleteCustomer(string name, string cpf)
        {
            var customerDefault = await _customerService.GetCustomerByName(name);

            var customer = customerDefault.FirstOrDefault(x => x.Cpf == cpf);

            if(customer != null)
            {
               await _customerService.DeleteCustomer(customer);
                return Ok();
            }

            return NotFound($"The Customer with the Name: {name} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{name}/{cpf}")]
        public async Task<CustomerModel>EditCustomer(string name, string cpf)
        {
            var customerDefault = await _customerService.GetCustomerByName(name);
 
            return await _customerService.EditCustomer(customerDefault, cpf);
        }
    }
}
