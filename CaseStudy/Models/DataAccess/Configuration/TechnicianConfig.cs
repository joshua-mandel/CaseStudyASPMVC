using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Models.DataAccess.Configuration
{
	internal class TechnicianConfig : IEntityTypeConfiguration<Technician>
	{
		public void Configure(EntityTypeBuilder<Technician> entity)
		{
			// seed initial data
			entity.HasData(
				new Technician { TechnicianId = 1, TechnicianName = "Alison Diaz", TechnicianEmail = "alison@sportsprosoftware.com", TechnicianPhone = "800-555-0443" },
				new Technician { TechnicianId = 2, TechnicianName = "Andrew Wilson", TechnicianEmail = "awilson@sportsprosoftware.com", TechnicianPhone = "800-555-0449" },
				new Technician { TechnicianId = 3, TechnicianName = "Gina Fiori", TechnicianEmail = "gfiori@sportsprosoftware.com", TechnicianPhone = "800-555-0459" },
				new Technician { TechnicianId = 4, TechnicianName = "Gunter Wendt", TechnicianEmail = "gunter@sportsprosoftware.com", TechnicianPhone = "800-555-0400" },
				new Technician { TechnicianId = 5, TechnicianName = "Jason Lee", TechnicianEmail = "jason@sportsprosoftware.com", TechnicianPhone = "800-555-0444" },
				new Technician { TechnicianId = -1, TechnicianName = "", TechnicianEmail = "", TechnicianPhone = "" }
			);
		}
	}
}
