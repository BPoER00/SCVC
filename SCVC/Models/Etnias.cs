using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Etnias")]
    public class Etnias
    {
        [Key]
        public int IdEtnia { get; set; }
        public string NombreEtnias { get; set; }
        public string Descripcion { get; set; }
    }
}