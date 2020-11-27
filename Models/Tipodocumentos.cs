using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tipodocumentos
    {
        public Tipodocumentos()
        {
            Documentos = new HashSet<Documentos>();
        }

        public int IdTipoDocumento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el tipo de documento")]
        public string DescripcionTipoDocumento { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
    }
}
