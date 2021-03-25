using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Repositories;
using System.Net.Http;

namespace CustomerMicroservice.Services
{
    public class CustomerService : ICustomerService
    {
        private IHttpClientFactory _httpClientFactory;
        private ICustomerRepository customerRepository;

        public CustomerService(IHttpClientFactory httpClientFactory, ICustomerRepository _transactionRepository)
        {
            _httpClientFactory = httpClientFactory;
            customerRepository = _transactionRepository;
        }

        public async Task<CustomerCreationStatus> CreateCustomer(Customer customer)
        {
            CustomerCreationStatus status = customerRepository.CreateCustomer(customer);
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:44331/api/customer");

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44386/api/account/createAccount?customerId=" + status.CustomerId, customer);
            if (response.IsSuccessStatusCode)
            {
                return status;
            }
            return null;
        }

        public Customer GetCustomerDetails(int customerId)
        {
            Customer customer = customerRepository.GetCustomerDetails(customerId);
            if (customer != null)
                return customer;
            else
                return null;
        }
    }
}
