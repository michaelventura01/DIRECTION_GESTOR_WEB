using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Relaciones
    {
        public int IdRelacion { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdPersonaRelacionFk { get; set; }
        public int IdTipoRelacionFk { get; set; }

        public Personas IdPersonaFkNavigation { get; set; }
        public Personas IdPersonaRelacionFkNavigation { get; set; }
        public Tiposrelaciones IdTipoRelacionFkNavigation { get; set; }
    }
}
