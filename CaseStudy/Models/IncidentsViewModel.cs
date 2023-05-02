namespace CaseStudy.Models
{
	public class IncidentsViewModel
	{
		public List<Incident> Incidents { get; set; } = new List<Incident>();
		public string IncidentFilter { get; set; } = "all";
	}
}
