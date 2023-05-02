using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
	public class AboutController : Controller
	{
		[Route("about")]
		public IActionResult About()
		{
			return View();
		}
	}
}
