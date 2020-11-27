using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Periodos
    {
        public Periodos()
        {
            Asignaturasempleadosestudiantes = new HashSet<Asignaturasempleadosestudiantes>();
        }

        public int IdPeriodo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionPeriodo { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Asignaturasempleadosestudiantes> Asignaturasempleadosestudiantes { get; set; }
    }
}
