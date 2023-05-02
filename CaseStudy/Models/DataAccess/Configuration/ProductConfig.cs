using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseStudy.Models;

namespace CaseStudy.Models.DataAccess.Configuration
{
	internal class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> entity)
		{
			// seed initial data
			entity.HasData(
					new Product { ProductId = 1, ProductCode = "TRNY10", ProductName = "Tournament Master 1.0", YearlyPrice = 4.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 2, ProductCode = "LEAG10", ProductName = "League Scheduler 1.0", YearlyPrice = 4.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 3, ProductCode = "LEAGD10", ProductName = "League Scheduler Deluxe 1.0", YearlyPrice = 7.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 4, ProductCode = "DRAFT10", ProductName = "Draft Manager 1.0", YearlyPrice = 4.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 5, ProductCode = "TEAM10", ProductName = "Team Manager 1.0", YearlyPrice = 4.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 6, ProductCode = "TRNY20", ProductName = "Tournament Master 2.0", YearlyPrice = 5.99, ReleaseDate = DateTime.Today },
					new Product { ProductId = 7, ProductCode = "DRAFT20", ProductName = "Draft Manager 2.0", YearlyPrice = 5.99, ReleaseDate = DateTime.Today }
				);
		}
	}
}
