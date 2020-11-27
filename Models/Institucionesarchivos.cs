using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Institucionesarchivos
    {
        public int IdArchivo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Enlace")]
        public string EnlaceArchivo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaArchivo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la hora")]
        public TimeSpan Hora { get; set; }
        public int IdTipoArchivoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
