using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_USUARIO")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string PassUser { get; set; }
        public int status { get; set; }
    }
}
