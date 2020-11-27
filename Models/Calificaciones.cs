using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Calificaciones
    {
        public int IdCalificacion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la calificacion")]
        public decimal Calificacion { get; set; }
        public int IdAsignaturaEmpleadoEstudianteFk { get; set; }
        public int IdEstadoFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaCalificacion { get; set; }
        public int IdInstitucionFk { get; set; }

        public Asignaturasempleadosestudiantes IdAsignaturaEmpleadoEstudianteFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
