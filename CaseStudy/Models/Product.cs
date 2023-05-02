using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseStudy.Models
{
	public class Product
	{
		public Product() => Customers = new HashSet<Customer>();
		public int ProductId { get; set; }

		[Required(ErrorMessage = "Please enter a code.")]
		public string ProductCode { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a name.")]
		public string ProductName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a yearly price.")]
		[Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
		public double? YearlyPrice { get; set; }

		[Required(ErrorMessage = "Please enter a date.")]
		public DateTime? ReleaseDate { get; set; }

		public string Slug()
		{
			return ProductName.Replace(' ', '-').ToLower();
		}

		public ICollection<Customer> Customers { get; set; }  // skip nav property

	}
}
