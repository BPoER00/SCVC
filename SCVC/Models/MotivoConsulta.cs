using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_MotivoConsulta")]
    public class MotivoConsulta
    {
       [Key]
       public int IdMotivoConsulta { get; set; }
       public string Descripcion { get; set; } 
    }
}