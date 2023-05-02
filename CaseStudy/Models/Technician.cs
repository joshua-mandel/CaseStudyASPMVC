using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseStudy.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string TechnicianName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string TechnicianEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string TechnicianPhone { get; set; } = string.Empty;

        public string Slug =>
            TechnicianName.Replace(' ', '-').ToLower();
    }
}
