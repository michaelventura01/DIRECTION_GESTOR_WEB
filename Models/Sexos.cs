using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Sexos
    {
        public Sexos()
        {
            Personas = new HashSet<Personas>();
        }

        public int IdSexo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el sexo")]
        public string DescripcionSexo { get; set; }

        public ICollection<Personas> Personas { get; set; }
    }
}
