using Microsoft.AspNetCore.Mvc;
using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CaseStudy.Models.DataAccess;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CaseStudy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CustomerController : Controller
	{
		private Repository<Customer> custData { get; set; }
		private Repository<Country> countryData { get; set; }

		public CustomerController(SportsProContext ctx)
		{
			custData = new Repository<Customer>(ctx);
			countryData = new Repository<Country>(ctx);
		}

		[Route("customers")]
		[HttpGet]
		public IActionResult List()
		{
			// list all customers
			var customers = custData.List(new QueryOptions<Customer>
			{
				OrderBy = c => c.LastName
			});
			return View(customers);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			// list all countries
			ViewBag.Countries = countryData.List(new QueryOptions<Country>
			{
				OrderBy = c => c.Name
			});
			return View("Edit", new Customer());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			ViewBag.Countries = countryData.List(new QueryOptions<Country>
			{
				OrderBy = c => c.Name
			});
			var customer = custData.Get(id);
			return View(customer);
		}

		[HttpPost]
		public IActionResult Edit(Customer customer)
		{
			if (ModelState.IsValid)
			{
				if (customer.CustomerId == 0)
				{
					custData.Insert(customer);
				}
				else
				{
					custData.Update(customer);
				}
				custData.Save();
				return RedirectToAction("List", "Customer");
			}
			else
			{
				ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
				ViewBag.Countries = countryData.List(new QueryOptions<Country>
				{
					OrderBy = c => c.Name
				});
				return View(customer);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var customer = custData.Get(id);
			return View(customer);
		}

		[HttpPost]
		public IActionResult Delete(Customer customer)
		{
			custData.Delete(customer);
			custData.Save();
			return RedirectToAction("List", "Customer");
		}
	}
}
