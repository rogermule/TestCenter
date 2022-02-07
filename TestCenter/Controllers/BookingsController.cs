using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCenter.Core.Models;
using TestCenter.Data.Context;
using TestCenter.Data.Repository;

namespace TestCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private TestCenterContext _dbContext;
        public BookingsController(TestCenterContext context)
        {
            _dbContext = context;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.Bookings.GetAll();
                    return Ok( item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.Bookings.GetByProperty(c => c.Id == id).Cast<Booking>()
                        .Include(c => c.TestCenters).Include(c => c.Availabilities).Include(c => c.Users).FirstOrDefault();

                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/<BookingsController>
        [HttpPost]
        public IActionResult Post([FromBody] Booking value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Bookings.Insert(value);
                    var result = context.Complete();

                    if (result.Status == OperationStatus.Success)
                    {
                        return Ok(value);
                    }

                    return BadRequest(result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Bookings.Update(value);
                    var result = context.Complete();

                    if (result.Status == OperationStatus.Success)
                    {
                        return Ok(value);
                    }
                    return BadRequest(result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Bookings.Delete(id);
                    var result = context.Complete();

                    if (result.Status == OperationStatus.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}
