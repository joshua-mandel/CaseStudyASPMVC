using Microsoft.AspNetCore.Mvc;
using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using CaseStudy.Models.DataAccess;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CaseStudy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class TechnicianController : Controller
	{
		private Repository<Technician> technicianData { get; set; }
		public TechnicianController(SportsProContext ctx)
		{
			technicianData = new Repository<Technician>(ctx);
		}

		[Route("technicians")]
		public IActionResult List()
		{
			List<Technician> technicians = technicianData.List(new QueryOptions<Technician>
			{
				OrderBy = t => t.TechnicianName,
				Where = t => t.TechnicianId > 0
			}).ToList();

			return View(technicians);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Technician());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			Technician technician = technicianData.Get(id)!;
			return View(technician);
		}

		[HttpPost]
		public IActionResult Edit(Technician technician)
		{
			if (ModelState.IsValid)
			{
				if (technician.TechnicianId == 0)
				{
					technicianData.Insert(technician);
				}
				else
				{
					technicianData.Update(technician);
				}
				technicianData.Save();

				return RedirectToAction("List", "Technician");
			}
			else
			{
				ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";

				return View(technician);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			Technician technician = technicianData.Get(id)!;

			return View(technician);
		}

		[HttpPost]
		public IActionResult Delete(Technician technician)
		{
			technicianData.Delete(technician);
			technicianData.Save();

			return RedirectToAction("List", "Technician");
		}
	}
}
