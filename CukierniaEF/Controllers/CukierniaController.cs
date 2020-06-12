using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CukierniaEF.DAL;
using CukierniaEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace CukierniaEF.Controllers
{
    [ApiController]
    [Route("api")]
    public class CukierniaController : ControllerBase
    {
        private DAL.IDbService _dbService;
        public CukierniaController(IDbService dbService)
        {

            _dbService = dbService;
        }
        [HttpGet("orders")]
        public IActionResult GetOrders(string LastName)
        {
            var param = HttpContext.Request;
            if (param.Query.ContainsKey("LastName"))
                return _dbService.GetOrders(LastName);
            return _dbService.GetOrders();
        }
        [HttpPost("clients/{id}/orders")]
        public IActionResult AddOrder(int id , AddOrd zam )
        {
            
            return _dbService.AddOrder(id , zam);
        
        }
    }
}