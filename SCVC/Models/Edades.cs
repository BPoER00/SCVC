using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Edades")]
    public class Edades
    {
        [Key]
        public int IdEdad { get; set; }
        public string NombreEdad { get; set; }
        public string Descripcion { get; set; }
        
    }
}