using System.ComponentModel.DataAnnotations;

namespace Simulation.Models
{
    public class Client
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
