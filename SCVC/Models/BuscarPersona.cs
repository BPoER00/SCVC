using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    public class BuscarPersona
    {
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string Usuario { get; set; }
    }
}