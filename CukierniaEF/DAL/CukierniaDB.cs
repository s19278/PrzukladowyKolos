using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CukierniaEF.Models;

namespace CukierniaEF.DAL
{
	public class CukierniaDB : Controller, IDbService
	{
		public IActionResult GetOrders()
		{
			var db = new s19278Context();
			var db2 = new s19278Context();
			var res = db.Zamowienie;
			List<OrdersReq> td = new List<OrdersReq>();
			foreach (var i in res)
			{
				var response = new OrdersReq()
				{

					IdZamowienia = i.IdZamowienia,
					DataPrzyjecia = i.DataPrzyjecia,
					DataRealizacji = i.DataRealizacji,
					IdKlient = i.IdKlient,
					IdPracownik = i.IdPracownik,
					Uwagi = i.Uwagi,
					list = db2.ZamowienieWyrobCukierniczy.Where(e => e.IdZamowienia == i.IdZamowienia).ToList()

				};
				td.Add(response);
				db2 = new s19278Context();
			}
			if (!res.Any()) 
			{
				return NotFound("Nie ma zadnych zamowien");
			}
			return Ok(td);
		}

		public IActionResult GetOrders(string LastName)
		{
			var db = new s19278Context();
			var db2 = new s19278Context();
			var req = db.Zamowienie.Where(e => e.IdKlientNavigation.Nazwisko == LastName);
			List<OrdersReq> td = new List<OrdersReq>();
			foreach (var i in req) {
				var response = new OrdersReq()
			{

				IdZamowienia = i.IdZamowienia,
				DataPrzyjecia = i.DataPrzyjecia,
				DataRealizacji = i.DataRealizacji,
				IdKlient = i.IdKlient,
				IdPracownik = i.IdPracownik,
				Uwagi = i.Uwagi,
					list = db2.ZamowienieWyrobCukierniczy.Where(e => e.IdZamowienia == i.IdZamowienia).ToList()

			};
				td.Add(response);
				db2 = new s19278Context();
			}
			
			if (req.Any())
			{
				return Ok(td);
			}
			else
				return NotFound("Klient o takim nazwisku nie zlozyl zamowienia");
		}

		IActionResult IDbService.AddOrder(int id, AddOrd zam)
		{

			var db = new s19278Context();
			var idZam = db.Zamowienie.Max(e => e.IdZamowienia) + 1;
			db.Add(new Zamowienie
			{
				DataPrzyjecia = zam.dataPrzyjecia,
				IdKlient = id,
				Uwagi = zam.uwagi,
				IdPracownik = 1,
				IdZamowienia = idZam
			}) ;
			foreach (var i in zam.wyroby) {
				db.Add(new ZamowienieWyrobCukierniczy
				{
					IdWyrobuCukierniczego = db.WyrobCukierniczy.Where(e => e.Nazwa == i.wyrob).FirstOrDefault().IdWyrobuCukierniczego,
					IdZamowienia = idZam,
					Ilosc = i.ilosc,
					Uwagi = i.uwagi
				
				});
			}
			db.SaveChanges();
			return Ok();
		}

	}
}
