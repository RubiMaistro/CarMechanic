using CarMechanic_Common.Models;
using CarMechanic_Server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMechanic_Server.Controllers
{
    [ApiController]
    [Route("api/customerorder")]
    public class CustomerOrderController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<CustomerOrder>> Get()
        {
            var orders = CustomerOrderRepository.GetCustomerOrders();

            if (orders != null)
            {
                return Ok(orders);
            }

            return NotFound("No customer order to display!");
            
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerOrder> Get(long id)
        {
            var order = CustomerOrderRepository.GetCustomerOrderById(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("Customer order not found!");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustomerOrder customerOrder)
        {
            CustomerOrderRepository.AddCustomerOrder(customerOrder);

            return Ok("Customer order adding successful!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(CustomerOrder customerOrder, long id)
        {
            var customerOrderFromDb = CustomerOrderRepository.GetCustomerOrderById(id);

            if (customerOrderFromDb != null)
            {
                CustomerOrderRepository.UpdateCustomerOrder(customerOrder);

                return Ok("Customer order updating successful!");
            }

            return NotFound("Customer order not found!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var customerOrder = CustomerOrderRepository.GetCustomerOrderById(id);

            if (customerOrder != null)
            {
                CustomerOrderRepository.DeleteCustomerOrder(customerOrder);

                return Ok("Customer order deleting successful!");
            }

            return NotFound("Customer order not found!");
        }
    }

}
