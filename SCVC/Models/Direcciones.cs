using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Direcciones")]
    public class Direcciones
    {
        [Key]
        public int IdDireccion { get; set; }   
        public string NombreDireccion { get; set; }
        public string Descripcion { get; set; }
    }
}