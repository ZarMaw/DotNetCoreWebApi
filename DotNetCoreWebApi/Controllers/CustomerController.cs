using DotNetCoreWebApi.Manager;
using DotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerManager _customerManager;
        public CustomerController(CustomerManager customerManager)
        {
            this._customerManager = customerManager;
        }
        [HttpPost]
        [Route("api/customer/insert")]
        public async Task<IActionResult> InsertCustomer(Customer customer)
        {
            string result = await _customerManager.InsertCustomer(customer);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/customer/getall")]
        public async Task<IActionResult> GetAllCustomer()
        {
            IEnumerable<Customer> result = await _customerManager.GetAllCustomer();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/customer/getbyid")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            var result = await _customerManager.GetCustomerById(customerId);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/customer/update")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            Customer result = await _customerManager.UpdateCustomer(customer);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/customer/delete")]
        public async Task<IActionResult> DeleteCustomer(Customer customer)
        {
            string result = await _customerManager.DeleteCustomer(customer);
            return Ok(result);
        }
    }
}
