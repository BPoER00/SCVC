using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_TipoConsulta")]
    public class TipoConsulta
    {
        [Key]
        public int IdTipoConsulta { get; set; }
        public string NombreTratamiento { get; set; }
        public string DescripcionTratamiento { get; set; }
        public int Cantidad { get; set; }
    }
}