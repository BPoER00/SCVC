using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_ConsultaCOVID")]
    public class ConsultaCOVID
    {
        [Key]
        public int IdConsultaCovid { get; set; }
        [Required(ErrorMessage = "El Campo CUI Paciente Es Necesario")]
        [StringLength(13, ErrorMessage = "El Campo No Puede Ser Mayor A 13")]
        public int DPIPacienteFK { get; set; }
        [Required(ErrorMessage = "El Campo CUI Medico Es Necesario")]
        [StringLength(13, ErrorMessage = "El Campo No Puede Ser Mayor A 13")]
        public int DPIMedicoFK { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public DateTime Fecha_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Direccion Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
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
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdVacunasFK { get; set; }
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int Dosis { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Prueba Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdTipoPrueba { get; set; }
        [Required(ErrorMessage = "El Campo Tipo Enfermedad Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdTipoEnfermedad { get; set; }
        [Required(ErrorMessage = "El Campo Hora Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo Hora es obligatorio ")]
        public DateTime HORA_COMMIT { get; set; }
        [Required(ErrorMessage = "El Campo Vigilancia Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdVigilancia { get; set; }
        [Required(ErrorMessage = "El Campo Clasificación Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdClasificacion { get; set; }
        [Required(ErrorMessage = "El Campo Usuario Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int IdUsuario { get; set; }


        //Llaves Foraneas
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Direcciones> Direcciones { get; set; }
        public virtual ICollection<Vacunas> Vacunas { get; set; }
        public virtual ICollection<TipoPrueba> TipoPrueba { get; set; }
        public virtual ICollection<TipoEnfermedad> TipoEnfermedad { get; set; }
        public virtual ICollection<Vigilancia> Vigilancia { get; set; }
        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}