using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestCenter.Data.Context;
using TestCenter.Data.Repository;

namespace TestCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, TestCenterContext context)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("Home/{id}")]
        public IActionResult Index(int id)
        {
            var dat = _unitOfWork.Users.GetById(id);
            _logger.LogInformation("Accessing users list");
            return Ok(dat);
        }

    }
}
