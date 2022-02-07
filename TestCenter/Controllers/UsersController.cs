using Microsoft.AspNetCore.Mvc;
using System;
using TestCenter.Data.Context;
using TestCenter.Data.Repository;
using TestCenter.Models;
using System.Linq;
using TestCenter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace TestCenter.Controllers
{
    public class UsersController : Controller
    {
        private TestCenterContext _dbContext;

        public UsersController(TestCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/<UsersController>/5
        [HttpPost]
        [Route("Users/Login")]
        public IActionResult Login([FromBody] UserLoginModel value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    var item = context.Users.GetByProperty(user => user.Email == value.Email && user.Password == value.Password).Cast<User>().FirstOrDefault();
                    if (item != null)
                    {
                        return Ok(new UserLoginResponseModel() {Name = item.Name, OperationResult = new OperationResult {Status = OperationStatus.Success, Message = "Login in sucess" } });
                    }
                    return Ok(new UserLoginResponseModel() {OperationResult = new OperationResult { Status = OperationStatus.Exception, Message = "User Not Found" } });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("Users/create")]
        public IActionResult Post([FromBody] User value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Users.Insert(value);
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

        // PUT api/<UsersController>/5
        [HttpPut]
        [Route("Users/update")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Users.Update(value);
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

        // DELETE api/<UsersController>/5
        [HttpDelete]
        [Route("Users/delete")]
        public IActionResult Delete(int id)
        {
            using (var context = new UnitOfWork(_dbContext))
            {
                try
                {
                    context.Users.Delete(id);
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
