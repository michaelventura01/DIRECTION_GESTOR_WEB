using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Saludobservaciones
    {
        public int IdSaludObservacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la observacion")]
        public string DescripcionSaludObservacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaSaludObservacion { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
    }
}
