using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Conductaobservaciones
    {
        public int IdConductaObservacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionConductaObservacion { get; set; }
        public DateTime FechaConductaObservacion { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
    }
}
