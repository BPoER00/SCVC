using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Vacunacion")]
    public class Vacunacion
    {
        [Key]
        public int IdVacunacion { get; set; }
        public int IdPersonaFK { get; set; }
        public int IdEnfermeroFK { get; set; }
        public int IdVacunaFK { get; set; }
        public int Dosis { get; set; }
        public DateTime Fecha_COMMIT { get; set; }
        public int IdUsuarioFK { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Vacunas> Vacunas { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    }
}