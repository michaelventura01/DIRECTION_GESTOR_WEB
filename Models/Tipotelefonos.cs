using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tipotelefonos
    {
        public Tipotelefonos()
        {
            Telefonos = new HashSet<Telefonos>();
        }

        public int IdTipoTelefono { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el tipo de telefono")]
        public string DescripcionTipoTelefono { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Telefonos> Telefonos { get; set; }
    }
}
