using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Roles")]
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }
}