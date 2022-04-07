using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Consulta")]
    public class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }
        [Required(ErrorMessage = "El Campo CUI Paciente Es Necesario")]
        [StringLength(13, ErrorMessage = "El Campo No Puede Ser Mayor A 13")]
        public int DPIPacienteFK { get; set; }
        [Required(ErrorMessage = "El Campo CUI medico Es Necesario")]
        [StringLength(13, ErrorMessage = "El Campo No Puede Ser Mayor A 13")]
        public int DPIMedicoFK { get; set; }
        [Required(ErrorMessage = "El Campo Motivo Consulta Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdMotivoConsultaFK { get; set; }
        [Required(ErrorMessage = "El Campo Tratamiento Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdTratamientoFK { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Consulta Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdTipoConsultaFK { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public DateTime Fecha_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Usuario Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdUsuario { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<MotivoConsulta> MotivoConsulta { get; set; }
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }
        public virtual ICollection<TipoConsulta> TipoConsultas { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    }
}