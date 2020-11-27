using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIRECTION_GESTOR.Migrations
{
    public partial class directionGestorMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__EMPLEADOS__idIns__51300E55",
                table: "EMPLEADOS");

            migrationBuilder.DropForeignKey(
                name: "FK__ESTUDIANT__idIns__5224328E",
                table: "ESTUDIANTES");

            migrationBuilder.DropIndex(
                name: "IX_ESTUDIANTES_idInstitucionFK",
                table: "ESTUDIANTES");

            migrationBuilder.DropIndex(
                name: "IX_EMPLEADOS_idInstitucionFK",
                table: "EMPLEADOS");

            migrationBuilder.DropColumn(
                name: "fechaInicioEstudiante",
                table: "ESTUDIANTES");

            migrationBuilder.DropColumn(
                name: "idInstitucionFK",
                table: "ESTUDIANTES");

            migrationBuilder.DropColumn(
                name: "fechaInicioEmpleado",
                table: "EMPLEADOS");

            migrationBuilder.DropColumn(
                name: "idInstitucionFK",
                table: "EMPLEADOS");

            migrationBuilder.AddColumn<string>(
                name: "nacionalidadPaisFK",
                table: "PERSONAS",
                unicode: false,
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nacionalidad",
                table: "PAISES",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EMPLEADOSINSTITUCIONES",
                columns: table => new
                {
                    idEmpleadoInstitucion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoEmpleadoFK = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLEADOSINSTITUCIONES", x => x.idEmpleadoInstitucion);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__codig__1B9317B3",
                        column: x => x.codigoEmpleadoFK,
                        principalTable: "EMPLEADOS",
                        principalColumn: "codigoEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EMPLEADOS__idIns__1C873BEC",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ESTUDIANTESINSTITUCIONES",
                columns: table => new
                {
                    idEmpleadoInstitucion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoEstudianteFK = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTUDIANTESINSTITUCIONES", x => x.idEmpleadoInstitucion);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__codig__1F63A897",
                        column: x => x.codigoEstudianteFK,
                        principalTable: "ESTUDIANTES",
                        principalColumn: "codigoEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__idIns__2057CCD0",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_nacionalidadPaisFK",
                table: "PERSONAS",
                column: "nacionalidadPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOSINSTITUCIONES_codigoEmpleadoFK",
                table: "EMPLEADOSINSTITUCIONES",
                column: "codigoEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOSINSTITUCIONES_idInstitucionFK",
                table: "EMPLEADOSINSTITUCIONES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTESINSTITUCIONES_codigoEstudianteFK",
                table: "ESTUDIANTESINSTITUCIONES",
                column: "codigoEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTESINSTITUCIONES_idInstitucionFK",
                table: "ESTUDIANTESINSTITUCIONES",
                column: "idInstitucionFK");

            migrationBuilder.AddForeignKey(
                name: "FK__PERSONAS__nacion__2EA5EC27",
                table: "PERSONAS",
                column: "nacionalidadPaisFK",
                principalTable: "PAISES",
                principalColumn: "idPais",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PERSONAS__nacion__2EA5EC27",
                table: "PERSONAS");

            migrationBuilder.DropTable(
                name: "EMPLEADOSINSTITUCIONES");

            migrationBuilder.DropTable(
                name: "ESTUDIANTESINSTITUCIONES");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_nacionalidadPaisFK",
                table: "PERSONAS");

            migrationBuilder.DropColumn(
                name: "nacionalidadPaisFK",
                table: "PERSONAS");

            migrationBuilder.DropColumn(
                name: "nacionalidad",
                table: "PAISES");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaInicioEstudiante",
                table: "ESTUDIANTES",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "idInstitucionFK",
                table: "ESTUDIANTES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaInicioEmpleado",
                table: "EMPLEADOS",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "idInstitucionFK",
                table: "EMPLEADOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTES_idInstitucionFK",
                table: "ESTUDIANTES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADOS_idInstitucionFK",
                table: "EMPLEADOS",
                column: "idInstitucionFK");

            migrationBuilder.AddForeignKey(
                name: "FK__EMPLEADOS__idIns__51300E55",
                table: "EMPLEADOS",
                column: "idInstitucionFK",
                principalTable: "INSTITUCIONES",
                principalColumn: "idInstitucion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__ESTUDIANT__idIns__5224328E",
                table: "ESTUDIANTES",
                column: "idInstitucionFK",
                principalTable: "INSTITUCIONES",
                principalColumn: "idInstitucion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
