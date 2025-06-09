using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SirvalApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dispositivos",
                columns: table => new
                {
                    Id_Dispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo_Disp = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_Disp = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ubicacion_Disp = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivos", x => x.Id_Dispositivo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "responsables",
                columns: table => new
                {
                    Id_Responsable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_Resp = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail_Resp = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsables", x => x.Id_Responsable);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipos_alerta",
                columns: table => new
                {
                    Id_TipoAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion_TipoAlerta = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_alerta", x => x.Id_TipoAlerta);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "registro_alertas",
                columns: table => new
                {
                    Id_Alerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_TipoAlerta = table.Column<int>(type: "int", nullable: false),
                    Id_Dispositivo = table.Column<int>(type: "int", nullable: false),
                    Severidad = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle_Alerta = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_Alerta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_alertas", x => x.Id_Alerta);
                    table.ForeignKey(
                        name: "FK_registro_alertas_dispositivos_Id_Dispositivo",
                        column: x => x.Id_Dispositivo,
                        principalTable: "dispositivos",
                        principalColumn: "Id_Dispositivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_registro_alertas_tipos_alerta_Id_TipoAlerta",
                        column: x => x.Id_TipoAlerta,
                        principalTable: "tipos_alerta",
                        principalColumn: "Id_TipoAlerta",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asignaciones",
                columns: table => new
                {
                    Id_Asignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Alerta = table.Column<int>(type: "int", nullable: false),
                    Id_Responsable = table.Column<int>(type: "int", nullable: false),
                    Fecha_Asig = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado_Asig = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observaciones_Asig = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaResol_Asig = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaciones", x => x.Id_Asignacion);
                    table.ForeignKey(
                        name: "FK_asignaciones_registro_alertas_Id_Alerta",
                        column: x => x.Id_Alerta,
                        principalTable: "registro_alertas",
                        principalColumn: "Id_Alerta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_asignaciones_responsables_Id_Responsable",
                        column: x => x.Id_Responsable,
                        principalTable: "responsables",
                        principalColumn: "Id_Responsable",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_asignaciones_Id_Alerta",
                table: "asignaciones",
                column: "Id_Alerta");

            migrationBuilder.CreateIndex(
                name: "IX_asignaciones_Id_Responsable",
                table: "asignaciones",
                column: "Id_Responsable");

            migrationBuilder.CreateIndex(
                name: "IX_registro_alertas_Id_Dispositivo",
                table: "registro_alertas",
                column: "Id_Dispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_registro_alertas_Id_TipoAlerta",
                table: "registro_alertas",
                column: "Id_TipoAlerta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignaciones");

            migrationBuilder.DropTable(
                name: "registro_alertas");

            migrationBuilder.DropTable(
                name: "responsables");

            migrationBuilder.DropTable(
                name: "dispositivos");

            migrationBuilder.DropTable(
                name: "tipos_alerta");
        }
    }
}
