using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tipocuentas
    {
        public Tipocuentas()
        {
            Cuentas = new HashSet<Cuentas>();
        }

        public int IdTipoCuenta { get; set; }
        [Required(ErrorMessage = "Debes Suministrar el tipo de cuenta")]
        public string DescripcionTipoCuenta { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Cuentas> Cuentas { get; set; }
    }
}
