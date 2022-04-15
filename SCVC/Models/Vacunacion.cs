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
        [Required(ErrorMessage = "El Campo Paciente Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdPersonaFK { get; set; }
        [Required(ErrorMessage = "El Campo Responsable Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdEnfermeroFK { get; set; }
        [Required(ErrorMessage = "El Campo Vacuna  Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdVacunaFK { get; set; }
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int Dosis { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public DateTime Fecha_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Ususario Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdUsuarioFK { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Vacunas> Vacunas { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    }
}