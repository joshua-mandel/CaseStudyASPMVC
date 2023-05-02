using CaseStudy.Models.DataAccess;

namespace CaseStudy.Models.Validation
{
	public static class Validate
	{
		public static string CheckEmail(Repository<Customer> customerData, Customer customer)
		{
			var dbCust = customerData.Get(new QueryOptions<Customer>
			{
				Where = c => c.EmailAddress == customer.EmailAddress && c.CustomerId != customer.CustomerId
			});

			if (dbCust == null)
			{
				return "";
			}
			else
			{
				return $"{customer.EmailAddress} is already in the database";
			}
		}
	}
}
