using CaseStudy.Models;
using CaseStudy.Models.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CaseStudy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RegistrationController : Controller
	{
		private Repository<Customer> customerData { get; set; }
		private Repository<Product> productData { get; set; }

		public RegistrationController(SportsProContext ctx)
		{
			customerData = new Repository<Customer>(ctx);
			productData = new Repository<Product>(ctx);
		}

		[HttpGet]
		public IActionResult Index()
		{
			RegistrationViewModel vm = new RegistrationViewModel();

			vm.Customers = customerData.List(new QueryOptions<Customer>
			{
				OrderBy = c => c.LastName
			}).ToList();

			return View(vm);
		}

		[HttpPost]
		public IActionResult List(RegistrationViewModel vm)
		{
			if (vm.Customer.CustomerId == 0)
			{
				TempData["message"] = "Please select a customer";

				vm.Customers = customerData.List(new QueryOptions<Customer>
				{
					OrderBy = c => c.LastName
				}).ToList();

				return RedirectToAction("Index", vm);
			}
			else
			{
				return RedirectToAction("List", new { id = vm.Customer.CustomerId });
			}
		}

		[HttpGet]
		public IActionResult List(int id)
		{
			RegistrationViewModel vm = new RegistrationViewModel();
			vm.Customer = customerData.Get(new QueryOptions<Customer>
			{
				Includes = "Products",
				Where = c => c.CustomerId == id
			})!;
			vm.Products = productData.List(new QueryOptions<Product>
			{
				OrderBy = p => p.ProductName
			}).ToList();

			vm.Customer.Products = vm.Customer.Products.OrderBy(p => p.ProductName).ToList();

			return View(vm);
		}

		[HttpPost]
		public IActionResult Delete(RegistrationViewModel vm, int id)
		{
			var customerId = vm.Customer.CustomerId;
			var productId = id;

			Product product = productData.Get(productId)!;

			Customer customer = customerData.Get(new QueryOptions<Customer>
			{
				Includes = "Products",
				Where = c => c.CustomerId == customerId
			})!;

			customer.Products.Remove(product);
			customerData.Save();

			vm.Products = productData.List(new QueryOptions<Product>
			{
				OrderBy = p => p.ProductName
			});

			vm.Customer = customer;

			return RedirectToAction("List", new { id = customerId });
		}

		[HttpPost]
		public IActionResult Add(RegistrationViewModel vm, int id)
		{
			var customerId = vm.Customer.CustomerId;
			var productId = id;

			var customer = customerData.Get(new QueryOptions<Customer>
			{
				Includes = "Products",
				Where = c => c.CustomerId == customerId
			})!;

			if (productId == 0)
			{
				TempData["message"] = $"Please select a product to add.";
				return RedirectToAction("List", new { id = customerId });
			}
			else
			{
				var product = productData.Get(productId);

				// check if the product is already associated with the user
				var customerWithProduct = customerData.Get(new QueryOptions<Customer>
				{
					Includes = "Products",
					Where = c => c.CustomerId == customerId
				})!;

				if (customerWithProduct.Products.Any(p => p.ProductId == productId))
				{
					TempData["message"] = $"{customer.FullName} already has {product?.ProductName} associated with them.";
					return RedirectToAction("List", new { id = customerId });
				}

				// add the product to the customers products and save changes
				customer.Products.Add(product!);
				customerData.Save();

				return RedirectToAction("List", new { id = customerId });
			}

		}
	}
}
