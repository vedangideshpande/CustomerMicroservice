using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerDetails(int customerId);
        CustomerCreationStatus CreateCustomer(Customer customer);
    }
}
