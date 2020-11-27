using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Cuentas
    {
        public int IdCuenta { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion de esta cuenta")]
        public string DescripcionCuenta { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el monto de la cuenta")]
        public decimal MontoCuenta { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaCuenta { get; set; }
        public int IdTipoCuentaFk { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
        public Tipocuentas IdTipoCuentaFkNavigation { get; set; }
    }
}
