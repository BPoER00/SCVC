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
        public string NombreVacuna { get; set; }
        public int Dosis { get; set; }
        public int IdGeneracion { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Generaciones> Generaciones { get; set; }
    }
}