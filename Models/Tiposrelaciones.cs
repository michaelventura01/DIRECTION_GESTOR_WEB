using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tiposrelaciones
    {
        public Tiposrelaciones()
        {
            Relaciones = new HashSet<Relaciones>();
        }

        public int IdTipoRelacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el tipo de relacion")]
        public string DescripcionTipoRelacion { get; set; }

        public ICollection<Relaciones> Relaciones { get; set; }
    }
}
