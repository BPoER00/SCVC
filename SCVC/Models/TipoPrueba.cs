using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_TipoPrueba")]
    public class TipoPrueba
    {
        [Key]
        public int IdTipoPrueba { get; set; }
        public string NombrePrueba { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }
    }
}