using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Roles")]
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El Campo Rol Es Necesario")]
        public string NombreRol { get; set; }
        [Required(ErrorMessage = "El Campo Descripción Es Necesario")]
        public string Descripcion { get; set; }
    }
}