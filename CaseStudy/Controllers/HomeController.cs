using CaseStudy.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaseStudy.Controllers
{
    public class HomeController : Controller
	{
		private SportsProContext context { get; set; }

		public HomeController(SportsProContext cxt) => context = cxt;

		public IActionResult Index()
		{
			return View();
		}
	}
}