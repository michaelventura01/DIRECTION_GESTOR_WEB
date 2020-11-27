using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Puestostrabajos
    {
        public Puestostrabajos()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdPuestoTrabajo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Puesto de Trabajo")]
        public string DescripcionPuestoTrabajo { get; set; }

        public ICollection<Empleados> Empleados { get; set; }
    }
}
