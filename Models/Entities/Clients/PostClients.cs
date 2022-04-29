using System.ComponentModel.DataAnnotations;

namespace API_FF6.Models.Entities.Clients
{
    public class PostClients
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
