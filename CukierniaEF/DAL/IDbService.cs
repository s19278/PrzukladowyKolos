using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CukierniaEF.Models;
using Microsoft.AspNetCore.Mvc;
namespace CukierniaEF.DAL
{
	public interface IDbService
	{

		public IActionResult GetOrders();
		public IActionResult GetOrders(String LastName);
		public IActionResult AddOrder(int id, AddOrd zam);
	}
}
