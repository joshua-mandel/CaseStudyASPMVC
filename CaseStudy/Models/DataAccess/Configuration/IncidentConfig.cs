using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Models.DataAccess.Configuration
{
	internal class IncidentConfig : IEntityTypeConfiguration<Incident>
	{
		public void Configure(EntityTypeBuilder<Incident> entity)
		{
			// seed initial data
			entity.HasData(
				new Incident { IncidentId = 1, CustomerId = 5, ProductId = 2, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 4, DateOpened = DateTime.Now },
				new Incident { IncidentId = 2, CustomerId = 2, ProductId = 7, Title = "Could not install", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 1, DateOpened = DateTime.Now },
				new Incident { IncidentId = 3, CustomerId = 3, ProductId = 1, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 3, DateOpened = DateTime.Now },
				new Incident { IncidentId = 4, CustomerId = 5, ProductId = 4, Title = "Program keeps crashing", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 2, DateOpened = DateTime.Now }
			);
		}
	}
}
