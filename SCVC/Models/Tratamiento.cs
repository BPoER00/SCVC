using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Tratamiento")]
    public class Tratamiento
    {
      [Key]
      public int IdTratamiento { get; set; }
      public string NombreTratamiento { get; set; }
      public string DescripcionTratamiento { get; set; }
      public int Cantidad { get; set; }  
    }
}