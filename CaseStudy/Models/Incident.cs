using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseStudy.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a product.")]
        public int? ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a customer.")]
        public int? CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

        public int? TechnicianId { get; set; }

        [ValidateNever]
        public Technician Technician { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a date for date opened.")]
        [DataType(DataType.Date)]
        public DateTime DateOpened { get; set; } = DateTime.Now;

        public DateTime? DateClosed { get; set; } = null!;
    }
}
