using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;
using CustomerMicroservice.Repositories;
using CustomerMicroservice.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroservice.Controllers
{
    //http://localhost:44331/api/customer/
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        
        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet("getCustomerDetails")]
        public IActionResult GetCustomerDetails(int customerId)
        {
            if(customerId <= 0)
            {
                return BadRequest("Customer ID must be greater than zero");
            }
            else
            {
                Customer customer = customerService.GetCustomerDetails(customerId);
                if (customer != null)
                    return Ok(customer);
                else
                    return NoContent();
            }
        }

        [HttpPost("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerCreationStatus status = await customerService.CreateCustomer(customer);
                if (status != null)
                {
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest("Customer creation failed");
            }

            //if (ModelState.IsValid)
            //{
            //    CustomerCreationStatus status = await customerService.CreateCustomer(customer);
            //
            //      return Ok(status);
            // 
            //   
            //}
            //else
            //{
            //    return BadRequest("Customer creation failed");
            //}
        }
    }
}