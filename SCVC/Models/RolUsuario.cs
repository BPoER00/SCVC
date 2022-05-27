using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{

    public class RolUsuario
    {
        [Key]
        public int IdRol { get; set; }
        [Required]
        public string NombreRol { get; set; }
    }
}