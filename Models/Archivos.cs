using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Archivos
    {
        public int IdArchivo { get; set; }
        public string EnlaceArchivo { get; set; }
        public DateTime FechaArchivo { get; set; }
        public TimeSpan Hora { get; set; }
        public int IdTipoArchivoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPersonaFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
        public Tiposarchivos IdTipoArchivoFkNavigation { get; set; }
    }
}
