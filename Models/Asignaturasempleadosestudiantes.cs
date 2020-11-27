using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Asignaturasempleadosestudiantes
    {
        public Asignaturasempleadosestudiantes()
        {
            Calificaciones = new HashSet<Calificaciones>();
        }

        public int IdAsignaturaEmpleadoEstudiante { get; set; }
        public int IdAsignaturaEmpleadoFk { get; set; }
        public string CodigoEstudianteFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPeriodoFk { get; set; }

        public Estudiantes CodigoEstudianteFkNavigation { get; set; }
        public Asignaturasempleados IdAsignaturaEmpleadoFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Periodos IdPeriodoFkNavigation { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; }
    }
}
