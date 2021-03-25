using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerDetails(int customerId);

        public Task<CustomerCreationStatus> CreateCustomer(Customer customer);
    }
}
