using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Responsabilidadobservaciones
    {
        public int IdResponsabilidadObservacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionResponsabilidadObservacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaResponsabilidadObservacion { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
    }
}
