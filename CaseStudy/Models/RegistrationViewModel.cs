namespace CaseStudy.Models
{
	public class RegistrationViewModel
	{
		public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

		public IEnumerable<Product> Products { get; set; } = new List<Product>();

		public Customer Customer { get; set; } = new Customer();

		public Product Product { get; set; } = new Product();
	}
}
