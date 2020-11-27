using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Actanacimiento = new HashSet<Actanacimiento>();
            Archivos = new HashSet<Archivos>();
            Articulos = new HashSet<Articulos>();
            Asignaturas = new HashSet<Asignaturas>();
            Asignaturasempleados = new HashSet<Asignaturasempleados>();
            Asignaturasempleadosestudiantes = new HashSet<Asignaturasempleadosestudiantes>();
            Aulas = new HashSet<Aulas>();
            Barrios = new HashSet<Barrios>();
            Calificaciones = new HashSet<Calificaciones>();
            Circunscripciones = new HashSet<Circunscripciones>();
            Ciudades = new HashSet<Ciudades>();
            Conductaobservaciones = new HashSet<Conductaobservaciones>();
            Correos = new HashSet<Correos>();
            Cuentas = new HashSet<Cuentas>();
            Cursos = new HashSet<Cursos>();
            Cursosasignaturas = new HashSet<Cursosasignaturas>();
            Direcciones = new HashSet<Direcciones>();
            Documentos = new HashSet<Documentos>();
            Edificios = new HashSet<Edificios>();
            Empleados = new HashSet<Empleados>();
            Enlaces = new HashSet<Enlaces>();
            Estudiantes = new HashSet<Estudiantes>();
            Instituciones = new HashSet<Instituciones>();
            Institucionescorreos = new HashSet<Institucionescorreos>();
            Institucionestelefonos = new HashSet<Institucionestelefonos>();
            Mensajes = new HashSet<Mensajes>();
            Movimientos = new HashSet<Movimientos>();
            Paises = new HashSet<Paises>();
            Periodos = new HashSet<Periodos>();
            Responsabilidadobservaciones = new HashSet<Responsabilidadobservaciones>();
            Roles = new HashSet<Roles>();
            Saludobservaciones = new HashSet<Saludobservaciones>();
            Tareas = new HashSet<Tareas>();
            Telefonos = new HashSet<Telefonos>();
            Tipocuentas = new HashSet<Tipocuentas>();
            Tipodocumentos = new HashSet<Tipodocumentos>();
            Tiposarchivos = new HashSet<Tiposarchivos>();
            Tipotelefonos = new HashSet<Tipotelefonos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionEstado { get; set; }
        [Required(ErrorMessage = "Debes Suministrar el estado")]
        public bool Estado { get; set; }
        public int IdDominioEstadoFk { get; set; }

        public Dominioestados IdDominioEstadoFkNavigation { get; set; }
        public ICollection<Actanacimiento> Actanacimiento { get; set; }
        public ICollection<Archivos> Archivos { get; set; }
        public ICollection<Articulos> Articulos { get; set; }
        public ICollection<Asignaturas> Asignaturas { get; set; }
        public ICollection<Asignaturasempleados> Asignaturasempleados { get; set; }
        public ICollection<Asignaturasempleadosestudiantes> Asignaturasempleadosestudiantes { get; set; }
        public ICollection<Aulas> Aulas { get; set; }
        public ICollection<Barrios> Barrios { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; }
        public ICollection<Circunscripciones> Circunscripciones { get; set; }
        public ICollection<Ciudades> Ciudades { get; set; }
        public ICollection<Conductaobservaciones> Conductaobservaciones { get; set; }
        public ICollection<Correos> Correos { get; set; }
        public ICollection<Cuentas> Cuentas { get; set; }
        public ICollection<Cursos> Cursos { get; set; }
        public ICollection<Cursosasignaturas> Cursosasignaturas { get; set; }
        public ICollection<Direcciones> Direcciones { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
        public ICollection<Edificios> Edificios { get; set; }
        public ICollection<Empleados> Empleados { get; set; }
        public ICollection<Enlaces> Enlaces { get; set; }
        public ICollection<Estudiantes> Estudiantes { get; set; }
        public ICollection<Instituciones> Instituciones { get; set; }
        public ICollection<Institucionescorreos> Institucionescorreos { get; set; }
        public ICollection<Institucionestelefonos> Institucionestelefonos { get; set; }
        public ICollection<Mensajes> Mensajes { get; set; }
        public ICollection<Movimientos> Movimientos { get; set; }
        public ICollection<Paises> Paises { get; set; }
        public ICollection<Periodos> Periodos { get; set; }
        public ICollection<Responsabilidadobservaciones> Responsabilidadobservaciones { get; set; }
        public ICollection<Roles> Roles { get; set; }
        public ICollection<Saludobservaciones> Saludobservaciones { get; set; }
        public ICollection<Tareas> Tareas { get; set; }
        public ICollection<Telefonos> Telefonos { get; set; }
        public ICollection<Tipocuentas> Tipocuentas { get; set; }
        public ICollection<Tipodocumentos> Tipodocumentos { get; set; }
        public ICollection<Tiposarchivos> Tiposarchivos { get; set; }
        public ICollection<Tipotelefonos> Tipotelefonos { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
