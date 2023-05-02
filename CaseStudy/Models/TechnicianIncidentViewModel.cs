namespace CaseStudy.Models
{
	public class TechnicianIncidentViewModel
	{
		public Technician Technician { get; set; } = new Technician();
		public Incident Incident { get; set; } = new Incident();
		public IEnumerable<Incident> Incidents { get; set; } = null!;
	}
}
