using DotNetCoreWebApi.Context;
using DotNetCoreWebApi.Models;
using DotNetCoreWebApi.Repositories;

namespace DotNetCoreWebApi.Manager
{
    public class CustomerManager
    {
        IBaseRepository<Customer> customerRepo;
        CustomerDbContext _context;
        public CustomerManager(CustomerDbContext context)
        {
            customerRepo = new BaseRepository<Customer>(context);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var customers =await customerRepo.GetAll();
            return customers;
        }
        public async Task<string> InsertCustomer(Customer customer)
        {
            try
            {
                customer.CustomerId = Guid.NewGuid();
                await customerRepo.Add(customer);
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            try
            {
                await customerRepo.Update(customer);
                return customer;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteCustomer(Customer customer)
        {
            try
            {
                await customerRepo.Delete(customer);
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Customer> GetCustomerById(Guid customerId)
        {
           var customer =  await customerRepo.GetById(customerId);
           return customer;
        }
    }
}
