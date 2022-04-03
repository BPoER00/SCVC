using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_TipoEnfermedad")]
    public class TipoEnfermedad
    {
        [Key]
        public int IdTipoEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string Descripcion { get; set; }
    }
}