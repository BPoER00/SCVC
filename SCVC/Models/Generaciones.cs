using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Generaciones")]
    public class Generaciones
    {
        [Key]
        public int IdGeneracion { get; set; }
        public string Generacion { get; set; }
        public string Descripcion { get; set; }
    }
}