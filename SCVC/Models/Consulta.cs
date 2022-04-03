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
        public int DPIPacienteFK { get; set; }
        public int DPIMedicoFK { get; set; }
        public int IdMotivoConsultaFK { get; set; }
        public int IdTratamientoFK { get; set; }
        public int IdTipoConsultaFK { get; set; }
        public DateTime Fecha_COMMIT { get; set; }
        public int IdUsuario { get; set; }

        //Llaves Foraneas
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<MotivoConsulta> MotivoConsulta { get; set; }
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }
        public virtual ICollection<TipoConsulta> TipoConsultas { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    }
}