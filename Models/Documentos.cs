using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Documentos
    {
        public int IdDocumento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la cuenta")]
        public string DescripcionDocumento { get; set; }

        public int IdTipoDocumentoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Tipodocumentos IdTipoDocumentoFkNavigation { get; set; }
    }
}
