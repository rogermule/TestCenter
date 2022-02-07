using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestCenter.Core.Models;
using TestCenter.Data.Context;
using TestCenter.Data.Repository;

namespace TestCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCenterAvailabilitiesController : ControllerBase
    {
        private TestCenterContext _dbContext;
        public TestCenterAvailabilitiesController(TestCenterContext context)
        {
            _dbContext = context;
        }

        // GET: api/<TestCenterAvailabilitiesController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.TestCenterAvailabilities.GetAll();
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // GET api/<TestCenterAvailabilitiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.TestCenterAvailabilities.GetById(id);
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/<TestCenterAvailabilitiesController>
        [HttpPost]
        public IActionResult Post([FromBody] TestCenterAvailability value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestCenterAvailabilities.Insert(value);
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

        // PUT api/<TestCenterAvailabilitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TestCenterAvailability value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestCenterAvailabilities.Update(value);
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

        // DELETE api/<TestCenterAvailabilitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestCenterAvailabilities.Delete(id);
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
