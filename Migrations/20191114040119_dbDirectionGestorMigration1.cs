using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIRECTION_GESTOR.Migrations
{
    public partial class dbDirectionGestorMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOMINIOESTADOS",
                columns: table => new
                {
                    idDominioEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionDominioEstado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOMINIOESTADOS", x => x.idDominioEstado);
                });

            migrationBuilder.CreateTable(
                name: "PRIORIDADES",
                columns: table => new
                {
                    idPrioridad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionPrioridad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIORIDADES", x => x.idPrioridad);
                });

            migrationBuilder.CreateTable(
                name: "PUESTOSTRABAJOS",
                columns: table => new
                {
                    idPuestoTrabajo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionPuestoTrabajo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUESTOSTRABAJOS", x => x.idPuestoTrabajo);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSRELACIONES",
                columns: table => new
                {
                    idTipoRelacion = table.Column<int>(nullable: false),
                    descripcionTipoRelacion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOSRELACIONES", x => x.idTipoRelacion);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    idEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionEstado = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    idDominioEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.idEstado);
                    table.ForeignKey(
                        name: "FK__ESTADOS__idDomin__6477ECF3",
                        column: x => x.idDominioEstadoFK,
                        principalTable: "DOMINIOESTADOS",
                        principalColumn: "idDominioEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CIRCUNSCRIPCIONES",
                columns: table => new
                {
                    idCircunscripcion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionCircunscripcion = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIRCUNSCRIPCIONES", x => x.idCircunscripcion);
                    table.ForeignKey(
                        name: "FK__CIRCUNSCR__idEst__76969D2E",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSTITUCIONES",
                columns: table => new
                {
                    idInstitucion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreInstitucion = table.Column<string>(type: "text", nullable: false),
                    descripcionInstitucion = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUCIONES", x => x.idInstitucion);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idEst__1CBC4616",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAISES",
                columns: table => new
                {
                    idPais = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    descripcionPais = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAISES", x => x.idPais);
                    table.ForeignKey(
                        name: "FK__PAISES__idEstado__75A278F5",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERIODOS",
                columns: table => new
                {
                    idPeriodo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionPeriodo = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERIODOS", x => x.idPeriodo);
                    table.ForeignKey(
                        name: "FK__PERIODOS__idEsta__114A936A",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    idRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionRol = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.idRol);
                    table.ForeignKey(
                        name: "FK__ROLES__idEstadoF__236943A5",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPOCUENTAS",
                columns: table => new
                {
                    idTipoCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionTipoCuenta = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOCUENTAS", x => x.idTipoCuenta);
                    table.ForeignKey(
                        name: "FK__TIPOCUENT__idEst__2DE6D218",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPODOCUMENTOS",
                columns: table => new
                {
                    idTipoDocumento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionTipoDocumento = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPODOCUMENTOS", x => x.idTipoDocumento);
                    table.ForeignKey(
                        name: "FK__TIPODOCUM__idEst__7C4F7684",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSARCHIVOS",
                columns: table => new
                {
                    idTipoArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionTipoArchivo = table.Column<string>(type: "text", nullable: false),
                    terminalTipoArchivo = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOSARCHIVOS", x => x.idTipoArchivo);
                    table.ForeignKey(
                        name: "FK__TIPOSARCH__idEst__6B24EA82",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPOTELEFONOS",
                columns: table => new
                {
                    idTipoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionTipoTelefono = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOTELEFONOS", x => x.idTipoTelefono);
                    table.ForeignKey(
                        name: "FK__TIPOTELEF__idEst__7F2BE32F",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ARTICULOS",
                columns: table => new
                {
                    idArticulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionArticulo = table.Column<string>(type: "text", nullable: false),
                    cantidadArticulo = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    precioArticulo = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    codigoArticulo = table.Column<string>(type: "text", nullable: false),
                    fechaArticulo = table.Column<string>(type: "text", nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICULOS", x => x.idArticulo);
                    table.ForeignKey(
                        name: "FK__ARTICULOS__idEst__2A164134",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ARTICULOS__idIns__5CA1C101",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASIGNATURAS",
                columns: table => new
                {
                    idAsignatura = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    descripcionAsignatura = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASIGNATURAS", x => x.idAsignatura);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idEst__10566F31",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idIns__59C55456",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CORREOS",
                columns: table => new
                {
                    idCorreo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionCorreo = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CORREOS", x => x.idCorreo);
                    table.ForeignKey(
                        name: "FK__CORREOS__idEstad__02084FDA",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CORREOS__idInsti__4F47C5E3",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CURSOS",
                columns: table => new
                {
                    idCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionCurso = table.Column<string>(type: "text", nullable: false),
                    tiempoCurso = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSOS", x => x.idCurso);
                    table.ForeignKey(
                        name: "FK__CURSOS__idEstado__06CD04F7",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CURSOS__idInstit__56E8E7AB",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMIENTOS",
                columns: table => new
                {
                    idMovimiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    montoMovimiento = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    descripcionMovimiento = table.Column<string>(type: "text", nullable: false),
                    idTipoMovimiento = table.Column<int>(nullable: false),
                    fechaMovimiento = table.Column<DateTime>(type: "date", nullable: false),
                    horaMovimiento = table.Column<TimeSpan>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMIENTOS", x => x.idMovimiento);
                    table.ForeignKey(
                        name: "FK__MOVIMIENT__idEst__2EDAF651",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MOVIMIENT__idIns__5F7E2DAC",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAREAS",
                columns: table => new
                {
                    idTarea = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tituloTarea = table.Column<string>(type: "text", nullable: false),
                    descripcionTarea = table.Column<string>(type: "text", nullable: false),
                    fechaTarea = table.Column<DateTime>(type: "date", nullable: false),
                    horaTarea = table.Column<TimeSpan>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPrioridadFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREAS", x => x.idTarea);
                    table.ForeignKey(
                        name: "FK__TAREAS__idEstado__2645B050",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TAREAS__idInstit__57DD0BE4",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TAREAS__idPriori__40058253",
                        column: x => x.idPrioridadFK,
                        principalTable: "PRIORIDADES",
                        principalColumn: "idPrioridad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CIUDADES",
                columns: table => new
                {
                    idCiudad = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    descripcionCiudad = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPaisFK = table.Column<string>(unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIUDADES", x => x.idCiudad);
                    table.ForeignKey(
                        name: "FK__CIUDADES__idEsta__73BA3083",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CIUDADES__idPais__74AE54BC",
                        column: x => x.idPaisFK,
                        principalTable: "PAISES",
                        principalColumn: "idPais",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENLACES",
                columns: table => new
                {
                    idEnlace = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionEnlace = table.Column<string>(type: "text", nullable: false),
                    urlEnlace = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idRolFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENLACES", x => x.idEnlace);
                    table.ForeignKey(
                        name: "FK__ENLACES__idEstad__245D67DE",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ENLACES__idInsti__5BAD9CC8",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ENLACES__idRolFK__25518C17",
                        column: x => x.idRolFK,
                        principalTable: "ROLES",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENTOS",
                columns: table => new
                {
                    idDocumento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionDocumento = table.Column<string>(type: "text", nullable: false),
                    idTipoDocumentoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTOS", x => x.idDocumento);
                    table.ForeignKey(
                        name: "FK__DOCUMENTO__idEst__7B5B524B",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DOCUMENTO__idIns__531856C7",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DOCUMENTO__idTip__7A672E12",
                        column: x => x.idTipoDocumentoFK,
                        principalTable: "TIPODOCUMENTOS",
                        principalColumn: "idTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ARCHIVOS",
                columns: table => new
                {
                    idArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enlaceArchivo = table.Column<string>(type: "text", nullable: false),
                    fechaArchivo = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<TimeSpan>(nullable: false),
                    idTipoArchivoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARCHIVOS", x => x.idArchivo);
                    table.ForeignKey(
                        name: "FK__ARCHIVOS__idEsta__6A30C649",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ARCHIVOS__idInst__55F4C372",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ARCHIVOS__idTipo__693CA210",
                        column: x => x.idTipoArchivoFK,
                        principalTable: "TIPOSARCHIVOS",
                        principalColumn: "idTipoArchivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONOS",
                columns: table => new
                {
                    idTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionTelefono = table.Column<string>(type: "text", nullable: false),
                    idTipoTelefonoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONOS", x => x.idTelefono);
                    table.ForeignKey(
                        name: "FK__TELEFONOS__idEst__7E37BEF6",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TELEFONOS__idIns__4E53A1AA",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TELEFONOS__idTip__7D439ABD",
                        column: x => x.idTipoTelefonoFK,
                        principalTable: "TIPOTELEFONOS",
                        principalColumn: "idTipoTelefono",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSTITUCIONESCORREOS",
                columns: table => new
                {
                    idInstitucionCorreo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idInstitucionFK = table.Column<int>(nullable: false),
                    idCorreoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUCIONESCORREOS", x => x.idInstitucionCorreo);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idCor__2180FB33",
                        column: x => x.idCorreoFK,
                        principalTable: "CORREOS",
                        principalColumn: "idCorreo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idEst__22751F6C",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idIns__208CD6FA",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CURSOSASIGNATURAS",
                columns: table => new
                {
                    idCursoAsignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idAsignaturaFK = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    idCursoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSOSASIGNATURAS", x => x.idCursoAsignatura);
                    table.ForeignKey(
                        name: "FK__CURSOSASI__idAsi__09A971A2",
                        column: x => x.idAsignaturaFK,
                        principalTable: "ASIGNATURAS",
                        principalColumn: "idAsignatura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CURSOSASI__idCur__0A9D95DB",
                        column: x => x.idCursoFK,
                        principalTable: "CURSOS",
                        principalColumn: "idCurso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CURSOSASI__idEst__0F624AF8",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BARRIOS",
                columns: table => new
                {
                    idBarrio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionBarrio = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idCiudadFK = table.Column<string>(unicode: false, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARRIOS", x => x.idBarrio);
                    table.ForeignKey(
                        name: "FK__BARRIOS__idCiuda__72C60C4A",
                        column: x => x.idCiudadFK,
                        principalTable: "CIUDADES",
                        principalColumn: "idCiudad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__BARRIOS__idEstad__71D1E811",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSTITUCIONESTELEFONOS",
                columns: table => new
                {
                    idInstitucionTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idInstitucionFK = table.Column<int>(nullable: false),
                    idTelefonoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUCIONESTELEFONOS", x => x.idInstitucionTelefono);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idEst__1F98B2C1",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idIns__1DB06A4F",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idTel__1EA48E88",
                        column: x => x.idTelefonoFK,
                        principalTable: "TELEFONOS",
                        principalColumn: "idTelefono",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIRECCIONES",
                columns: table => new
                {
                    idDireccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionDireccion = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idBarrioFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIRECCIONES", x => x.idDireccion);
                    table.ForeignKey(
                        name: "FK__DIRECCION__idBar__6D0D32F4",
                        column: x => x.idBarrioFK,
                        principalTable: "BARRIOS",
                        principalColumn: "idBarrio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DIRECCION__idEst__6C190EBB",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DIRECCION__idIns__58D1301D",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDIFICIOS",
                columns: table => new
                {
                    idEdificio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionEdificio = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idDireccionFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDIFICIOS", x => x.idEdificio);
                    table.ForeignKey(
                        name: "FK__EDIFICIOS__idDir__6EF57B66",
                        column: x => x.idDireccionFK,
                        principalTable: "DIRECCIONES",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EDIFICIOS__idEst__6E01572D",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EDIFICIOS__idIns__540C7B00",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAS",
                columns: table => new
                {
                    idPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombrePersonas = table.Column<string>(type: "text", nullable: false),
                    apellidoPersonas = table.Column<string>(type: "text", nullable: false),
                    fechaNacimientoPersona = table.Column<DateTime>(type: "date", nullable: false),
                    idDireccionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAS", x => x.idPersona);
                    table.ForeignKey(
                        name: "FK__PERSONAS__idDire__656C112C",
                        column: x => x.idDireccionFK,
                        principalTable: "DIRECCIONES",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AULAS",
                columns: table => new
                {
                    idAula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionAula = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idEdificioFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AULAS", x => x.idAula);
                    table.ForeignKey(
                        name: "FK__AULAS__idEdifici__70DDC3D8",
                        column: x => x.idEdificioFK,
                        principalTable: "EDIFICIOS",
                        principalColumn: "idEdificio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AULAS__idEstadoF__6FE99F9F",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AULAS__idInstitu__55009F39",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACTANACIMIENTO",
                columns: table => new
                {
                    idActaNacimiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    folioActaNacimiento = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    anioActaNacimiento = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    libroActaNacimiento = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    numeroActaNacimiento = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idCircunscripcionFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTANACIMIENTO", x => x.idActaNacimiento);
                    table.ForeignKey(
                        name: "FK__ACTANACIM__idCir__797309D9",
                        column: x => x.idCircunscripcionFK,
                        principalTable: "CIRCUNSCRIPCIONES",
                        principalColumn: "idCircunscripcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ACTANACIM__idEst__787EE5A0",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ACTANACIM__idIns__4D5F7D71",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ACTANACIM__idPer__778AC167",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONDUCTAOBSERVACIONES",
                columns: table => new
                {
                    idConductaObservacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionConductaObservacion = table.Column<string>(type: "text", nullable: false),
                    fechaConductaObservacion = table.Column<DateTime>(type: "date", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDUCTAOBSERVACIONES", x => x.idConductaObservacion);
                    table.ForeignKey(
                        name: "FK__CONDUCTAO__idEst__69FBBC1F",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CONDUCTAO__idPer__671F4F74",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUENTAS",
                columns: table => new
                {
                    idCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionCuenta = table.Column<string>(type: "text", nullable: false),
                    montoCuenta = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    fechaCuenta = table.Column<DateTime>(type: "date", nullable: false),
                    idTipoCuentaFK = table.Column<int>(nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUENTAS", x => x.idCuenta);
                    table.ForeignKey(
                        name: "FK__CUENTAS__idEstad__2CF2ADDF",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CUENTAS__idInsti__503BEA1C",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CUENTAS__idPerso__2BFE89A6",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CUENTAS__idTipoC__2B0A656D",
                        column: x => x.idTipoCuentaFK,
                        principalTable: "TIPOCUENTAS",
                        principalColumn: "idTipoCuenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLEADOS",
                columns: table => new
                {
                    codigoEmpleado = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    sueldoEmpleado = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    fechaInicioEmpleado = table.Column<DateTime>(type: "date", nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPuestoTrabajoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLEADOS", x => x.codigoEmpleado);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__idEst__0D7A0286",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__idIns__51300E55",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__idPer__0C85DE4D",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__idPue__0E6E26BF",
                        column: x => x.idPuestoTrabajoFK,
                        principalTable: "PUESTOSTRABAJOS",
                        principalColumn: "idPuestoTrabajo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ESTUDIANTES",
                columns: table => new
                {
                    codigoEstudiante = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    fechaInicioEstudiante = table.Column<DateTime>(type: "date", nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTUDIANTES", x => x.codigoEstudiante);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__idEst__05D8E0BE",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__idIns__5224328E",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__idPer__04E4BC85",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONASCORREOS",
                columns: table => new
                {
                    idPersonaCorreo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idCorreoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONASCORREOS", x => x.idPersonaCorreo);
                    table.ForeignKey(
                        name: "FK__PERSONASC__idCor__03F0984C",
                        column: x => x.idCorreoFK,
                        principalTable: "CORREOS",
                        principalColumn: "idCorreo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PERSONASC__idPer__02FC7413",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONASTELEFONOS",
                columns: table => new
                {
                    idPersonaTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idTelefonoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONASTELEFONOS", x => x.idPersonaTelefono);
                    table.ForeignKey(
                        name: "FK__PERSONAST__idPer__00200768",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PERSONAST__idTel__01142BA1",
                        column: x => x.idTelefonoFK,
                        principalTable: "TELEFONOS",
                        principalColumn: "idTelefono",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RELACIONES",
                columns: table => new
                {
                    idRelacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idPersonaRelacionFK = table.Column<int>(nullable: false),
                    idTipoRelacionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RELACIONES", x => x.idRelacion);
                    table.ForeignKey(
                        name: "FK__RELACIONE__idPer__66603565",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__RELACIONE__idPer__6754599E",
                        column: x => x.idPersonaRelacionFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__RELACIONE__idTip__68487DD7",
                        column: x => x.idTipoRelacionFK,
                        principalTable: "TIPOSRELACIONES",
                        principalColumn: "idTipoRelacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSABILIDADOBSERVACIONES",
                columns: table => new
                {
                    idResponsabilidadObservacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionResponsabilidadObservacion = table.Column<string>(type: "text", nullable: false),
                    fechaResponsabilidadObservacion = table.Column<DateTime>(type: "date", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSABILIDADOBSERVACIONES", x => x.idResponsabilidadObservacion);
                    table.ForeignKey(
                        name: "FK__RESPONSAB__idEst__6AEFE058",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__RESPONSAB__idPer__681373AD",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SALUDOBSERVACIONES",
                columns: table => new
                {
                    idSaludObservacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionSaludObservacion = table.Column<string>(type: "text", nullable: false),
                    fechaSaludObservacion = table.Column<DateTime>(type: "date", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALUDOBSERVACIONES", x => x.idSaludObservacion);
                    table.ForeignKey(
                        name: "FK__SALUDOBSE__idEst__690797E6",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SALUDOBSE__idPer__662B2B3B",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameUsuario = table.Column<string>(type: "text", nullable: false),
                    passwordUsuario = table.Column<string>(type: "text", nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idRolFK = table.Column<int>(nullable: false),
                    idPersonaFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__USUARIOS__idEsta__19DFD96B",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__USUARIOS__idInst__5D95E53A",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__USUARIOS__idPers__1BC821DD",
                        column: x => x.idPersonaFK,
                        principalTable: "PERSONAS",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__USUARIOS__idRolF__1AD3FDA4",
                        column: x => x.idRolFK,
                        principalTable: "ROLES",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASIGNATURASEMPLEADOS",
                columns: table => new
                {
                    idAsignaturaEmpleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoEmpleadoFK = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    idEstadoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASIGNATURASEMPLEADOS", x => x.idAsignaturaEmpleado);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__codig__123EB7A3",
                        column: x => x.codigoEmpleadoFK,
                        principalTable: "EMPLEADOS",
                        principalColumn: "codigoEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idEst__1332DBDC",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ESTUDIANTESCURSOS",
                columns: table => new
                {
                    idEstudianteCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoEstudianteFK = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    idCursoFK = table.Column<int>(nullable: false),
                    fechaEstudianteCurso = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTUDIANTESCURSOS", x => x.idEstudianteCurso);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__codig__07C12930",
                        column: x => x.codigoEstudianteFK,
                        principalTable: "ESTUDIANTES",
                        principalColumn: "codigoEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__idCur__08B54D69",
                        column: x => x.idCursoFK,
                        principalTable: "CURSOS",
                        principalColumn: "idCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MENSAJES",
                columns: table => new
                {
                    idMensaje = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tituloMensaje = table.Column<string>(type: "text", nullable: false),
                    descripcionMensaje = table.Column<string>(type: "text", nullable: false),
                    idUsuarioEmisorFK = table.Column<int>(nullable: false),
                    idUsuarioReceptorFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAJES", x => x.idMensaje);
                    table.ForeignKey(
                        name: "FK__MENSAJES__idEsta__29221CFB",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MENSAJES__idInst__5E8A0973",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MENSAJES__idUsua__2739D489",
                        column: x => x.idUsuarioEmisorFK,
                        principalTable: "USUARIOS",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MENSAJES__idUsua__282DF8C2",
                        column: x => x.idUsuarioReceptorFK,
                        principalTable: "USUARIOS",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASIGNATURASEMPLEADOSESTUDIANTES",
                columns: table => new
                {
                    idAsignaturaEmpleadoEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idAsignaturaEmpleadoFK = table.Column<int>(nullable: false),
                    codigoEstudianteFK = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idPeriodoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASIGNATURASEMPLEADOSESTUDIANTES", x => x.idAsignaturaEmpleadoEstudiante);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__codig__151B244E",
                        column: x => x.codigoEstudianteFK,
                        principalTable: "ESTUDIANTES",
                        principalColumn: "codigoEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idAsi__14270015",
                        column: x => x.idAsignaturaEmpleadoFK,
                        principalTable: "ASIGNATURASEMPLEADOS",
                        principalColumn: "idAsignaturaEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idEst__160F4887",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ASIGNATUR__idPer__17036CC0",
                        column: x => x.idPeriodoFK,
                        principalTable: "PERIODOS",
                        principalColumn: "idPeriodo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CALIFICACIONES",
                columns: table => new
                {
                    idCalificacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    calificacion = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    idAsignaturaEmpleadoEstudianteFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    fechaCalificacion = table.Column<DateTime>(type: "date", nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CALIFICACIONES", x => x.idCalificacion);
                    table.ForeignKey(
                        name: "FK__CALIFICAC__idAsi__17F790F9",
                        column: x => x.idAsignaturaEmpleadoEstudianteFK,
                        principalTable: "ASIGNATURASEMPLEADOSESTUDIANTES",
                        principalColumn: "idAsignaturaEmpleadoEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CALIFICAC__idEst__18EBB532",
                        column: x => x.idEstadoFK,
                        principalTable: "ESTADOS",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CALIFICAC__idIns__5AB9788F",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTANACIMIENTO_idCircunscripcionFK",
                table: "ACTANACIMIENTO",
                column: "idCircunscripcionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ACTANACIMIENTO_idEstadoFK",
                table: "ACTANACIMIENTO",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ACTANACIMIENTO_idInstitucionFK",
                table: "ACTANACIMIENTO",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ACTANACIMIENTO_idPersonaFK",
                table: "ACTANACIMIENTO",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_idEstadoFK",
                table: "ARCHIVOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_idInstitucionFK",
                table: "ARCHIVOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_idTipoArchivoFK",
                table: "ARCHIVOS",
                column: "idTipoArchivoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICULOS_idEstadoFK",
                table: "ARTICULOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICULOS_idInstitucionFK",
                table: "ARTICULOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURAS_idEstadoFK",
                table: "ASIGNATURAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURAS_idInstitucionFK",
                table: "ASIGNATURAS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOS_codigoEmpleadoFK",
                table: "ASIGNATURASEMPLEADOS",
                column: "codigoEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOS_idEstadoFK",
                table: "ASIGNATURASEMPLEADOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOSESTUDIANTES_codigoEstudianteFK",
                table: "ASIGNATURASEMPLEADOSESTUDIANTES",
                column: "codigoEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOSESTUDIANTES_idAsignaturaEmpleadoFK",
                table: "ASIGNATURASEMPLEADOSESTUDIANTES",
                column: "idAsignaturaEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOSESTUDIANTES_idEstadoFK",
                table: "ASIGNATURASEMPLEADOSESTUDIANTES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ASIGNATURASEMPLEADOSESTUDIANTES_idPeriodoFK",
                table: "ASIGNATURASEMPLEADOSESTUDIANTES",
                column: "idPeriodoFK");

            migrationBuilder.CreateIndex(
                name: "IX_AULAS_idEdificioFK",
                table: "AULAS",
                column: "idEdificioFK");

            migrationBuilder.CreateIndex(
                name: "IX_AULAS_idEstadoFK",
                table: "AULAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_AULAS_idInstitucionFK",
                table: "AULAS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_BARRIOS_idCiudadFK",
                table: "BARRIOS",
                column: "idCiudadFK");

            migrationBuilder.CreateIndex(
                name: "IX_BARRIOS_idEstadoFK",
                table: "BARRIOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CALIFICACIONES_idAsignaturaEmpleadoEstudianteFK",
                table: "CALIFICACIONES",
                column: "idAsignaturaEmpleadoEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_CALIFICACIONES_idEstadoFK",
                table: "CALIFICACIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CALIFICACIONES_idInstitucionFK",
                table: "CALIFICACIONES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_CIRCUNSCRIPCIONES_idEstadoFK",
                table: "CIRCUNSCRIPCIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CIUDADES_idEstadoFK",
                table: "CIUDADES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CIUDADES_idPaisFK",
                table: "CIUDADES",
                column: "idPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_CONDUCTAOBSERVACIONES_idEstadoFK",
                table: "CONDUCTAOBSERVACIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CONDUCTAOBSERVACIONES_idPersonaFK",
                table: "CONDUCTAOBSERVACIONES",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CORREOS_idEstadoFK",
                table: "CORREOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CORREOS_idInstitucionFK",
                table: "CORREOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_CUENTAS_idEstadoFK",
                table: "CUENTAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CUENTAS_idInstitucionFK",
                table: "CUENTAS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_CUENTAS_idPersonaFK",
                table: "CUENTAS",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CUENTAS_idTipoCuentaFK",
                table: "CUENTAS",
                column: "idTipoCuentaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CURSOS_idEstadoFK",
                table: "CURSOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CURSOS_idInstitucionFK",
                table: "CURSOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_CURSOSASIGNATURAS_idAsignaturaFK",
                table: "CURSOSASIGNATURAS",
                column: "idAsignaturaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CURSOSASIGNATURAS_idCursoFK",
                table: "CURSOSASIGNATURAS",
                column: "idCursoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CURSOSASIGNATURAS_idEstadoFK",
                table: "CURSOSASIGNATURAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_idBarrioFK",
                table: "DIRECCIONES",
                column: "idBarrioFK");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_idEstadoFK",
                table: "DIRECCIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_idInstitucionFK",
                table: "DIRECCIONES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTOS_idEstadoFK",
                table: "DOCUMENTOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTOS_idInstitucionFK",
                table: "DOCUMENTOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTOS_idTipoDocumentoFK",
                table: "DOCUMENTOS",
                column: "idTipoDocumentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_EDIFICIOS_idDireccionFK",
                table: "EDIFICIOS",
                column: "idDireccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_EDIFICIOS_idEstadoFK",
                table: "EDIFICIOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_EDIFICIOS_idInstitucionFK",
                table: "EDIFICIOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_idEstadoFK",
                table: "EMPLEADOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_idInstitucionFK",
                table: "EMPLEADOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_idPersonaFK",
                table: "EMPLEADOS",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_idPuestoTrabajoFK",
                table: "EMPLEADOS",
                column: "idPuestoTrabajoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ENLACES_idEstadoFK",
                table: "ENLACES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ENLACES_idInstitucionFK",
                table: "ENLACES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ENLACES_idRolFK",
                table: "ENLACES",
                column: "idRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_idDominioEstadoFK",
                table: "ESTADOS",
                column: "idDominioEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTES_idEstadoFK",
                table: "ESTUDIANTES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTES_idInstitucionFK",
                table: "ESTUDIANTES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTES_idPersonaFK",
                table: "ESTUDIANTES",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTESCURSOS_codigoEstudianteFK",
                table: "ESTUDIANTESCURSOS",
                column: "codigoEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTESCURSOS_idCursoFK",
                table: "ESTUDIANTESCURSOS",
                column: "idCursoFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONES_idEstadoFK",
                table: "INSTITUCIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESCORREOS_idCorreoFK",
                table: "INSTITUCIONESCORREOS",
                column: "idCorreoFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESCORREOS_idEstadoFK",
                table: "INSTITUCIONESCORREOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESCORREOS_idInstitucionFK",
                table: "INSTITUCIONESCORREOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESTELEFONOS_idEstadoFK",
                table: "INSTITUCIONESTELEFONOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESTELEFONOS_idInstitucionFK",
                table: "INSTITUCIONESTELEFONOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESTELEFONOS_idTelefonoFK",
                table: "INSTITUCIONESTELEFONOS",
                column: "idTelefonoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAJES_idEstadoFK",
                table: "MENSAJES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAJES_idInstitucionFK",
                table: "MENSAJES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAJES_idUsuarioEmisorFK",
                table: "MENSAJES",
                column: "idUsuarioEmisorFK");

            migrationBuilder.CreateIndex(
                name: "IX_MENSAJES_idUsuarioReceptorFK",
                table: "MENSAJES",
                column: "idUsuarioReceptorFK");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMIENTOS_idEstadoFK",
                table: "MOVIMIENTOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMIENTOS_idInstitucionFK",
                table: "MOVIMIENTOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_PAISES_idEstadoFK",
                table: "PAISES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERIODOS_idEstadoFK",
                table: "PERIODOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_idDireccionFK",
                table: "PERSONAS",
                column: "idDireccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONASCORREOS_idCorreoFK",
                table: "PERSONASCORREOS",
                column: "idCorreoFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONASCORREOS_idPersonaFK",
                table: "PERSONASCORREOS",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONASTELEFONOS_idPersonaFK",
                table: "PERSONASTELEFONOS",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONASTELEFONOS_idTelefonoFK",
                table: "PERSONASTELEFONOS",
                column: "idTelefonoFK");

            migrationBuilder.CreateIndex(
                name: "IX_RELACIONES_idPersonaFK",
                table: "RELACIONES",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_RELACIONES_idPersonaRelacionFK",
                table: "RELACIONES",
                column: "idPersonaRelacionFK");

            migrationBuilder.CreateIndex(
                name: "IX_RELACIONES_idTipoRelacionFK",
                table: "RELACIONES",
                column: "idTipoRelacionFK");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSABILIDADOBSERVACIONES_idEstadoFK",
                table: "RESPONSABILIDADOBSERVACIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSABILIDADOBSERVACIONES_idPersonaFK",
                table: "RESPONSABILIDADOBSERVACIONES",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_idEstadoFK",
                table: "ROLES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_SALUDOBSERVACIONES_idEstadoFK",
                table: "SALUDOBSERVACIONES",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_SALUDOBSERVACIONES_idPersonaFK",
                table: "SALUDOBSERVACIONES",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_idEstadoFK",
                table: "TAREAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_idInstitucionFK",
                table: "TAREAS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_idPrioridadFK",
                table: "TAREAS",
                column: "idPrioridadFK");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOS_idEstadoFK",
                table: "TELEFONOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOS_idInstitucionFK",
                table: "TELEFONOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOS_idTipoTelefonoFK",
                table: "TELEFONOS",
                column: "idTipoTelefonoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TIPOCUENTAS_idEstadoFK",
                table: "TIPOCUENTAS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TIPODOCUMENTOS_idEstadoFK",
                table: "TIPODOCUMENTOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TIPOSARCHIVOS_idEstadoFK",
                table: "TIPOSARCHIVOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TIPOTELEFONOS_idEstadoFK",
                table: "TIPOTELEFONOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_idEstadoFK",
                table: "USUARIOS",
                column: "idEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_idInstitucionFK",
                table: "USUARIOS",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_idPersonaFK",
                table: "USUARIOS",
                column: "idPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_idRolFK",
                table: "USUARIOS",
                column: "idRolFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTANACIMIENTO");

            migrationBuilder.DropTable(
                name: "ARCHIVOS");

            migrationBuilder.DropTable(
                name: "ARTICULOS");

            migrationBuilder.DropTable(
                name: "AULAS");

            migrationBuilder.DropTable(
                name: "CALIFICACIONES");

            migrationBuilder.DropTable(
                name: "CONDUCTAOBSERVACIONES");

            migrationBuilder.DropTable(
                name: "CUENTAS");

            migrationBuilder.DropTable(
                name: "CURSOSASIGNATURAS");

            migrationBuilder.DropTable(
                name: "DOCUMENTOS");

            migrationBuilder.DropTable(
                name: "ENLACES");

            migrationBuilder.DropTable(
                name: "ESTUDIANTESCURSOS");

            migrationBuilder.DropTable(
                name: "INSTITUCIONESCORREOS");

            migrationBuilder.DropTable(
                name: "INSTITUCIONESTELEFONOS");

            migrationBuilder.DropTable(
                name: "MENSAJES");

            migrationBuilder.DropTable(
                name: "MOVIMIENTOS");

            migrationBuilder.DropTable(
                name: "PERSONASCORREOS");

            migrationBuilder.DropTable(
                name: "PERSONASTELEFONOS");

            migrationBuilder.DropTable(
                name: "RELACIONES");

            migrationBuilder.DropTable(
                name: "RESPONSABILIDADOBSERVACIONES");

            migrationBuilder.DropTable(
                name: "SALUDOBSERVACIONES");

            migrationBuilder.DropTable(
                name: "TAREAS");

            migrationBuilder.DropTable(
                name: "CIRCUNSCRIPCIONES");

            migrationBuilder.DropTable(
                name: "TIPOSARCHIVOS");

            migrationBuilder.DropTable(
                name: "EDIFICIOS");

            migrationBuilder.DropTable(
                name: "ASIGNATURASEMPLEADOSESTUDIANTES");

            migrationBuilder.DropTable(
                name: "TIPOCUENTAS");

            migrationBuilder.DropTable(
                name: "ASIGNATURAS");

            migrationBuilder.DropTable(
                name: "TIPODOCUMENTOS");

            migrationBuilder.DropTable(
                name: "CURSOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "CORREOS");

            migrationBuilder.DropTable(
                name: "TELEFONOS");

            migrationBuilder.DropTable(
                name: "TIPOSRELACIONES");

            migrationBuilder.DropTable(
                name: "PRIORIDADES");

            migrationBuilder.DropTable(
                name: "ESTUDIANTES");

            migrationBuilder.DropTable(
                name: "ASIGNATURASEMPLEADOS");

            migrationBuilder.DropTable(
                name: "PERIODOS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "TIPOTELEFONOS");

            migrationBuilder.DropTable(
                name: "EMPLEADOS");

            migrationBuilder.DropTable(
                name: "PERSONAS");

            migrationBuilder.DropTable(
                name: "PUESTOSTRABAJOS");

            migrationBuilder.DropTable(
                name: "DIRECCIONES");

            migrationBuilder.DropTable(
                name: "BARRIOS");

            migrationBuilder.DropTable(
                name: "INSTITUCIONES");

            migrationBuilder.DropTable(
                name: "CIUDADES");

            migrationBuilder.DropTable(
                name: "PAISES");

            migrationBuilder.DropTable(
                name: "ESTADOS");

            migrationBuilder.DropTable(
                name: "DOMINIOESTADOS");
        }
    }
}
