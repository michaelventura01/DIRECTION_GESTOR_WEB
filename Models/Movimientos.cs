using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Movimientos
    {
        public int IdMovimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Monto")]
        public decimal MontoMovimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaMovimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la hora")]
        public TimeSpan HoraMovimiento { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
