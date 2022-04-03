using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Clasificacion")]
    public class Clasificacion
    {
        [Key]
        public int IdClasificacion { get; set; }
        public string NombreClasificacion { get; set; }
    }
}