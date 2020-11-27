using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Personascorreos
    {
        public int IdPersonaCorreo { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdCorreoFk { get; set; }

        public Correos IdCorreoFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
    }
}
