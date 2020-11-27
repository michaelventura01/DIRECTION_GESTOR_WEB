using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Articulos
    {
        public int IdArticulo { get; set; }
        [Required(ErrorMessage = "Debes Suministrar la descripcion del Articulo")]
        public string DescripcionArticulo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la Cantidad")]
        public decimal CantidadArticulo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Precio")]
        public decimal PrecioArticulo { get; set; }

        public int IdEstadoFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el codigo para el Articulo")]
        public string CodigoArticulo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la Fecha")]
        public string FechaArticulo { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
