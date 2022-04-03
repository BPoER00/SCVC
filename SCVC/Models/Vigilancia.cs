using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Vigilancia")]
    public class Vigilancia
    {
        [Key]
        public int IdVigilancia { get; set; }
        public string NombreVigilancia { get; set; }
        public string Descripcion { get; set; }
    }
}