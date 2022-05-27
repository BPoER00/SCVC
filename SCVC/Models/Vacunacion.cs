using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_VACUNACION")]
    public class Vacunacion : DatosUsuarios
    {
        [Key]
        public int IdVacunacion { get; set; }

        [Required(ErrorMessage = "El Campo Paciente Es Necesario")]
        public int IdPersona { get; set; }
        
        [Required(ErrorMessage = "El Campo Responsable Es Necesario")]
        public int IdEnfermero { get; set; }
        
        [Required(ErrorMessage = "El Campo Vacuna  Es Necesario")]
        public int IdVacuna { get; set; }
        
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        public int Dosis { get; set; }
        
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        public DateTime Fecha_COMMIT { get; set; }
        
        [Required(ErrorMessage = "El Campo Ususario Es Necesario")]
        public int IdUsuario { get; set; }

        //Llaves Foraneas
        public virtual Vacunas Vacunas { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Usuarios Usuarios { get; set; }

    }
}