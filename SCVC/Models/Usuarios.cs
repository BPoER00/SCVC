using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_USUARIO")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El Campo Usuarios Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El Campo Contraseña Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string PassUser { get; set; }
        public int status { get; set; }
    }
}
