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
    public class PcrCentersController : ControllerBase
    {

        private TestCenterContext _dbContext;
        public PcrCentersController(TestCenterContext context)
        {
            _dbContext = context;
        }

        // GET: api/<PcrCentersController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.PcrCenters.GetAll();
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // GET api/<PcrCentersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.PcrCenters.GetById(id);
                    return Ok(item);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/<PcrCentersController>
        [HttpPost]
        public IActionResult Post([FromBody] PcrCenter value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.PcrCenters.Insert(value);
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

        // PUT api/<PcrCentersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PcrCenter value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.PcrCenters.Update(value);
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

        // DELETE api/<PcrCentersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.PcrCenters.Delete(id);
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
