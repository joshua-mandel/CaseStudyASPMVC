using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Models.DataAccess.Configuration
{
	internal class CountryConfig : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> entity)
		{
			// seed initial data
			entity.HasData(
				new Country { CountryId = "A", Name = "United States" },
				new Country { CountryId = "B", Name = "Mexico" },
				new Country { CountryId = "C", Name = "Canada" },
				new Country { CountryId = "D", Name = "United Kingdom" },
				new Country { CountryId = "E", Name = "Australia" }
			);
		}
	}
}
