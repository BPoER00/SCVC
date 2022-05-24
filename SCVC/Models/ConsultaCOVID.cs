using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_CONSULTACOVID")]
    public class ConsultaCOVID
    {
        [Key]
        public int IdConsultaCovid { get; set; }
        [Required(ErrorMessage = "El Campo CUI Paciente Es Necesario")]
        public int DPIPacienteFK { get; set; }
        [Required(ErrorMessage = "El Campo CUI Medico Es Necesario")]
        public int DPIMedicoFK { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public DateTime Fecha_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Direccion Es Necesario")]
        public int IdDireccionFK { get; set; }
        [Required(ErrorMessage = "El Campo Trabajo Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string Trabajo { get; set; }
        [Required(ErrorMessage = "El Campo Sintomas Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string Sintomas { get; set; }
        [Required(ErrorMessage = "El Campo Enfermedades Cronicas Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string EnfermedadesCronicas { get; set; }
        [Required(ErrorMessage = "El Campo vacunas Es Necesario")]
        public int IdVacunasFK { get; set; }
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        public int Dosis { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Prueba Es Necesario")]
        public int IdTipoPrueba { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Enfermedad Es Necesario")]
        public int IdTipoEnfermedad { get; set; }
        [Required(ErrorMessage = "El Campo Hora Es Necesario")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo Hora es obligatorio ")]
        public DateTime HORA_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Vigilancia Es Necesario")]
        public int IdVigilancia { get; set; }
        [Required(ErrorMessage = "El Campo Clasificación Es Necesario")]
        public int IdClasificacion { get; set; }
        [Required(ErrorMessage = "El Campo Usuario Es Necesario")]
        public int IdUsuario { get; set; }


        //Llaves Foraneas
        public virtual Persona Persona { get; set; }
        public virtual Direcciones Direcciones { get; set; }
        public virtual Vacunas Vacunas { get; set; }
        public virtual TipoPrueba TipoPrueba { get; set; }
        public virtual TipoEnfermedad TipoEnfermedad { get; set; }
        public virtual Vigilancia Vigilancia { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}