using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OrderContext orderdb;
        public ValuesController(OrderContext context)
        {
            this.orderdb = context;
        }
        [HttpGet]
        public ActionResult<List<OrderItem>> Get()
        {
            IQueryable<OrderItem> query = orderdb.OrderItems;
            return query.ToList();
        }

        // GETapi
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = orderdb.Orders.FirstOrDefault(t => t.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api
        [HttpPost]
        public ActionResult<Order> Post(Order order)
        {
            try
            {
                orderdb.Orders.Add(order);
                orderdb.SaveChanges();
            }catch(Exception e ){
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT api
        [HttpPut("{id}")]
        public ActionResult<Order> Put(string ID,Order order)
        {
            if(ID!= order.ID)
            {
                return BadRequest("id cannot be modified!");
            }
            try{
                orderdb.Entry(order).State = EntityState.Modified;
                orderdb.SaveChanges();
            }catch(Exception e){
                string error = e.Message;
                if(e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try{
                var order = orderdb.Orders.FirstOrDefault(t => t.ID == id);
                if(order != null){
                    orderdb.Remove(orderdb);
                    orderdb.SaveChanges();
                }
                }catch(Exception e){
                    return BadRequest(e.InnerException.Message);
                }
                return NoContent();
            }
        }
    }

