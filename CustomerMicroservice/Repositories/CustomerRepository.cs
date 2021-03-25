using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Data;

namespace CustomerMicroservice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerCreationStatus CreateCustomer(Customer customer)
        {
            try
            {
                CustomerCreationStatus customerstatus = new CustomerCreationStatus();
                customer.CustomerId = (CustomerDbHelper.customers.Max(a => a.CustomerId)) + 1;
                CustomerDbHelper.customers.Add(customer);
                int id = customer.CustomerId;
                customerstatus.CustomerId = id;
                customerstatus.Status = "Success";
                return customerstatus;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Customer GetCustomerDetails(int customerId)
        {
            try
            {
                return CustomerDbHelper.customers.Find(x => x.CustomerId == customerId);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
