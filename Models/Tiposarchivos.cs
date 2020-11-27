using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tiposarchivos
    {
        public Tiposarchivos()
        {
            Archivos = new HashSet<Archivos>();
        }

        public int IdTipoArchivo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el tipo de archivo")]
        public string DescripcionTipoArchivo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el terminal del archivo")]
        public string TerminalTipoArchivo { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Archivos> Archivos { get; set; }
    }
}
