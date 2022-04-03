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
        public int DPIPacienteFK { get; set; }
        public int DPIMedicoFK { get; set; }
        public DateTime Fecha_COMMIT { get; set; }
        public int IdDireccionFK { get; set; }
        public string Trabajo { get; set; }
        public string Sintomas { get; set; }
        public string EnfermedadesCronicas { get; set; }
        public int IdVacunasFK { get; set; }
        public int Dosis { get; set; }
        public int IdTipoPrueba { get; set; }
        public int IdTipoEnfermedad { get; set; }
        public DateTime HORA_COMMIT { get; set; }
        public int IdVigilancia { get; set; }
        public int IdClasificacion { get; set; }
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