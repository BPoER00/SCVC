using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Generos")]
    public class Generos
    {
        [Key]
        public int IdGenero { get; set; }
        public string NombreGenero { get; set; }
        public string Descripcion { get; set; }
    }
}