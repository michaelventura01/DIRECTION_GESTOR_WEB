using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            Asignaturasempleados = new HashSet<Asignaturasempleados>();
            Empleadosinstituciones = new HashSet<Empleadosinstituciones>();
        }

        [Required(ErrorMessage = "Debes Suministrar el codigo del empleado")]
        public string CodigoEmpleado { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el sueldo")]
        public decimal SueldoEmpleado { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPuestoTrabajoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
        public Puestostrabajos IdPuestoTrabajoFkNavigation { get; set; }
        public ICollection<Asignaturasempleados> Asignaturasempleados { get; set; }
        public ICollection<Empleadosinstituciones> Empleadosinstituciones { get; set; }
    }
}
