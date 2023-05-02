using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseStudy.Models
{
	public class Customer
	{
		public Customer() => Products = new HashSet<Product>();
		public int CustomerId { get; set; }

		[Required(ErrorMessage = "Please enter a first name.")]
		[StringLength(51, ErrorMessage = "First name cannot be longer than 51 characters.")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a last name.")]
		[StringLength(51, ErrorMessage = "Last name cannot be longer than 51 characters.")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an address.")]
		[StringLength(51, ErrorMessage = "Address cannot be longer than 51 characters.")]
		public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a city.")]
		[StringLength(51, ErrorMessage = "City cannot be longer than 51 characters.")]
		public string City { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a state.")]
		[StringLength(51, ErrorMessage = "State cannot be longer than 51 characters.")]
		public string State { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a postal code.")]
		[StringLength(21, ErrorMessage = "Postal code cannot be longer than 21 characters.")]
		public string PostalCode { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please select a country.")]
		public string CountryId { get; set; } = string.Empty;

		[ValidateNever]
		public Country Country { get; set; } = null!;

		[StringLength(51, ErrorMessage = "Email address cannot be longer than 51 characters.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
		[Remote("CheckEmail", "Validation", AdditionalFields = nameof(CustomerId))]
		public string? EmailAddress { get; set; } = null!;

		[RegularExpression("^((\\+0?1\\s)?)\\(?\\d{3}\\)?[\\s.\\s]\\d{3}[\\s.-]\\d{4}$", ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
		public string? Phone { get; set; } = null!;

		public string FullName => $"{FirstName} {LastName}";

		public string Slug =>
			FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

		public ICollection<Product> Products { get; set; } // skip nav property
	}
}
