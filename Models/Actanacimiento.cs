using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Actanacimiento
    {
        
        public int IdActaNacimiento { get; set; }

        [Required(ErrorMessage ="Debes Suministrar el Folio")]
        [MinLength(4, ErrorMessage = "Deben ser almenos 4 digitos")]
        [MaxLength(6, ErrorMessage = "Deben ser menos de 6 digitos")]
        public string FolioActaNacimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Año")]
        [MinLength(4, ErrorMessage = "Deben ser almenos 4 digitos")]
        [MaxLength(4, ErrorMessage = "Deben ser menos de 4 digitos")]
        public string AnioActaNacimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Libro")]
        [MinLength(4, ErrorMessage = "Deben ser almenos 4 digitos")]
        [MaxLength(7, ErrorMessage = "Deben ser menos de 6 digitos")]
        public string LibroActaNacimiento { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Numero de Acta")]
        [MinLength(4, ErrorMessage = "Deben ser almenos 4 digitos")]
        [MaxLength(7, ErrorMessage = "Deben ser menos de 6 digitos")]
        public string NumeroActaNacimiento { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdCircunscripcionFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Circunscripciones IdCircunscripcionFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
    }
}
