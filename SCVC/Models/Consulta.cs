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
        public int DPIPacienteFK { get; set; }
        [Required(ErrorMessage = "El Campo CUI medico Es Necesario")]
        public int DPIMedicoFK { get; set; }
        [Required(ErrorMessage = "El Campo Motivo Consulta Es Necesario")]
        public int IdMotivoConsultaFK { get; set; }
        [Required(ErrorMessage = "El Campo Tratamiento Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdTratamientoFK { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Consulta Es Necesario")]
        public int IdTipoConsultaFK { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public DateTime Fecha_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Usuario Es Necesario")]
        public int IdUsuario { get; set; }

        //Llaves Foraneas
        public virtual Persona Persona { get; set; }
        public virtual MotivoConsulta MotivoConsulta { get; set; }
        public virtual Tratamiento Tratamiento { get; set; }
        public virtual TipoConsulta TipoConsultas { get; set; }
        public virtual Usuarios Usuarios { get; set; }

    }
}