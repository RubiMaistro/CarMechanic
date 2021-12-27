using CarMechanic_Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMechanic_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrderController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<CustomerOrder>> Get()
        {
            return Ok("Show the Client Objects");
        }

        [HttpGet]
        public ActionResult<CustomerOrder> Get(long id)
        {
            return Ok("Show a Client Object");
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustomerOrder client)
        {
            return Ok();
        }
    }
}
