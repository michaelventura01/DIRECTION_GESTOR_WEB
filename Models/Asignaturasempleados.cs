using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Asignaturasempleados
    {
        public Asignaturasempleados()
        {
            Asignaturasempleadosestudiantes = new HashSet<Asignaturasempleadosestudiantes>();
        }

        public int IdAsignaturaEmpleado { get; set; }
        public string CodigoEmpleadoFk { get; set; }
        public int IdEstadoFk { get; set; }

        public Empleados CodigoEmpleadoFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Asignaturasempleadosestudiantes> Asignaturasempleadosestudiantes { get; set; }
    }
}
