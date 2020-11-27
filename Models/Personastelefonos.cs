using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Personastelefonos
    {
        public int IdPersonaTelefono { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdTelefonoFk { get; set; }

        public Personas IdPersonaFkNavigation { get; set; }
        public Telefonos IdTelefonoFkNavigation { get; set; }
    }
}
