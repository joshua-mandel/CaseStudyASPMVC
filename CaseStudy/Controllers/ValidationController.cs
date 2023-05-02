using CaseStudy.Models;
using CaseStudy.Models.DataAccess;
using CaseStudy.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
	public class ValidationController : Controller
	{
		private Repository<Customer> customerData { get; set; }

		public ValidationController(SportsProContext ctx)
		{
			customerData = new Repository<Customer>(ctx);
		}

		public JsonResult CheckEmail(string emailAddress, int customerId)
		{
			Customer customer = new Customer { EmailAddress = emailAddress, CustomerId = customerId };

			string msg = Validate.CheckEmail(customerData, customer);

			if (string.IsNullOrEmpty(msg))
			{
				return Json(true);
			}
			else
			{
				return Json(msg);
			}
		}
	}
}
