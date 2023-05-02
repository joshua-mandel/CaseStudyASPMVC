using Microsoft.AspNetCore.Mvc;
using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CaseStudy.Models.DataAccess;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CaseStudy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncidentController : Controller
    {
        private Repository<Incident> incidentData { get; set; }
        private Repository<Customer> customerData { get; set; }
        private Repository<Product> productData { get; set; }
        private Repository<Technician> technicianData { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            incidentData = new Repository<Incident>(ctx);
            customerData = new Repository<Customer>(ctx);
            productData = new Repository<Product>(ctx);
            technicianData = new Repository<Technician>(ctx);
        }

        [Route("incidents/{id?}")]
        public IActionResult List(string id)
        {
            var vm = new IncidentsViewModel();
            if (!id.IsNullOrEmpty())
            {
                vm.IncidentFilter = id;
            }

            // Use incidentData instead of context
            List<Incident> incidents = incidentData.List(new QueryOptions<Incident>
            {
                Includes = "Customer,Product"
            }).ToList();

            if (vm.IncidentFilter == "unassigned")
            {
                incidents = incidents.Where(i => i.TechnicianId == -1 || i.TechnicianId == null).ToList();
            }
            else if (vm.IncidentFilter == "open")
            {
                incidents = incidents.Where(i => i.DateClosed == null).ToList();
            }

            vm.Incidents = incidents.OrderBy(i => i.Title).ToList();

            return View(vm);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var vm = new IncidentAddEditViewModel();
            vm.Action = "Add";

            vm.Customers = customerData.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            }).ToList();

            vm.Products = productData.List(new QueryOptions<Product>
            {
                OrderBy = p => p.ProductName
            }).ToList();

            vm.Technicians = technicianData.List(new QueryOptions<Technician>
            {
                OrderBy = t => t.TechnicianName,
                Where = t => t.TechnicianId > 0
            }).ToList();

            return View("Edit", vm);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var vm = new IncidentAddEditViewModel();
            vm.Action = "Edit";

            vm.Customers = customerData.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            }).ToList();

            vm.Products = productData.List(new QueryOptions<Product>
            {
                OrderBy = p => p.ProductName
            }).ToList();

            vm.Technicians = technicianData.List(new QueryOptions<Technician>
            {
                OrderBy = t => t.TechnicianName,
                Where = t => t.TechnicianId > 0
            }).ToList();

            vm.Incident = incidentData.Get(id)!;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(IncidentAddEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Incident.IncidentId == 0)
                {
                    incidentData.Insert(vm.Incident);
                }
                else
                {
                    incidentData.Update(vm.Incident);
                }
                incidentData.Save();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                vm.Action = (vm.Incident.IncidentId == 0) ? "Add" : "Edit";
                vm.Customers = customerData.List(new QueryOptions<Customer>
                {
                    OrderBy = c => c.LastName
                }).ToList();

                vm.Products = productData.List(new QueryOptions<Product>
                {
                    OrderBy = p => p.ProductName
                }).ToList();

                vm.Technicians = technicianData.List(new QueryOptions<Technician>
                {
                    OrderBy = t => t.TechnicianName,
                    Where = t => t.TechnicianId > 0
                }).ToList();

                return View(vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var incident = incidentData.Get(id);
            return View(incident);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            incidentData.Delete(incident);
            incidentData.Save();
            return RedirectToAction("List", "Incident");
        }
    }
}
