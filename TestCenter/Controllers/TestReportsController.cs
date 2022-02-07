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
    public class TestReportsController : ControllerBase
    {
        private TestCenterContext _dbContext;
        public TestReportsController(TestCenterContext context)
        {
            _dbContext = context;
        }

        // GET: api/<TestReportsController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.TestReports.GetAll();
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // GET api/<TestReportsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.TestReports.GetById(id);
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/<TestReportsController>
        [HttpPost]
        public IActionResult Post([FromBody] TestReport value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestReports.Insert(value);
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

        // PUT api/<TestReportsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TestReport value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestReports.Update(value);
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

        // DELETE api/<TestReportsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.TestReports.Delete(id);
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
