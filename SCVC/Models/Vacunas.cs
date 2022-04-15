using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Vacunas")]
    public class Vacunas
    {
        [Key]
        public int IdVacuna { get; set; }
        [Required(ErrorMessage = "El Campo Nombre Vacuna Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string NombreVacuna { get; set; }
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int Dosis { get; set; }
        [Required(ErrorMessage = "El Campo Generación Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdGeneracion { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Generaciones> Generaciones { get; set; }
    }
}