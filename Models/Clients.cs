using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_FF6.Models
{
    public class Clients
    {
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]       
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        [NotMapped]
        public int Age { get; set; }

    }
}
