using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Empleadosinstituciones
    {
        public int IdEmpleadoInstitucion { get; set; }
        public string CodigoEmpleadoFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha de inicio")]
        public DateTime FechaInicio { get; set; }
        public int IdInstitucionFk { get; set; }

        public Empleados CodigoEmpleadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
